using MongoDB.Driver;

public class MongoService
{
    private readonly IMongoCollection<Movie> _collection;

    public MongoService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase("MovieStore");
        _collection = database.GetCollection<Movie>("Movies");
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}
