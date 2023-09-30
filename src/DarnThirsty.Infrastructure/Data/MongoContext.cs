using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
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
    }

    public IMongoCollection<User> Users
    {
        get
        {
            return _mongoDatabase.GetCollection<User>(nameof(User).ToLower());
        }
    }
}