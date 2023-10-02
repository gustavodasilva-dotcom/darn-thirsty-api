using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Infrastructure.Data.Seeders;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Data;

public class MongoContext : IMongoContext
{
    private readonly MongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IConfiguration _configuration;

    public MongoContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _mongoClient = new MongoClient(_configuration["MongoDB:ConnectionString"]);
        _mongoDatabase = _mongoClient.GetDatabase(_configuration["MongoDB:Database"]);

        RunSeedersAsync().Wait();
    }

    public IMongoCollection<User> Users
    {
        get
        {
            return _mongoDatabase.GetCollection<User>(nameof(User).ToLower());
        }
    }

    public IMongoCollection<DrinkType> DrinkTypes
    {
        get
        {
            return _mongoDatabase.GetCollection<DrinkType>(nameof(DrinkType).ToLower());
        }
    }

    public IMongoCollection<Drink> Drinks
    {
        get
        {
            return _mongoDatabase.GetCollection<Drink>(nameof(Drink).ToLower());
        }
    }

    public async Task RunSeedersAsync()
    {
        await DrinkTypesSeeder.RunAsync(DrinkTypes);
    }
}