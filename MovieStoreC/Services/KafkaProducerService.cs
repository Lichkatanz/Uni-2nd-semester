using Confluent.Kafka;
using System.Text.Json;

public class KafkaProducerService
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducerService(IConfiguration config)
    {
        var bootstrapServers = config["Kafka:BootstrapServers"];
        var producerConfig = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, object data)
    {
        var message = new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = JsonSerializer.Serialize(data)
        };
        await _producer.ProduceAsync(topic, message);
    }
}
