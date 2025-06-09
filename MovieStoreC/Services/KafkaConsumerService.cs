using Confluent.Kafka;
using Microsoft.Extensions.Caching.Memory;

public class KafkaConsumerService : BackgroundService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly IMemoryCache _cache;

    public KafkaConsumerService(IConfiguration config, IMemoryCache cache)
    {
        var bootstrapServers = config["Kafka:BootstrapServers"];
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = "cache-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        _cache = cache;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("cache-topic");
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = _consumer.Consume(stoppingToken);
            _cache.Set(message.Key, message.Value);
        }
    }
}
