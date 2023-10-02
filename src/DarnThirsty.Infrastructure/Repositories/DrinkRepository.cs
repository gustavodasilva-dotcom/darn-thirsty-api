using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DarnThirsty.Infrastructure.Repositories;

public class DrinkRepository : IDrinkRepository
{
	private readonly IMongoContext _mongoContext;

    public DrinkRepository(IMongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }

    public async Task<IEnumerable<Drink>> GetAll(int skip = 0, int limit = 50)
    {
        return await _mongoContext.Drinks.Find(u => true).Skip(skip).Limit(limit).ToListAsync();
    }

    public async Task<IEnumerable<Drink>> GetAll(Expression<Func<Drink, bool>> expression)
    {
        return await _mongoContext.Drinks.Find(expression).ToListAsync();
    }

    public Task<Drink> Get(Expression<Func<Drink, bool>> expression)
    {
        return _mongoContext.Drinks.FindSync(expression).FirstOrDefaultAsync();
    }

    public async Task Save(Drink drink)
    {
        await _mongoContext.Drinks.InsertOneAsync(drink);
    }

    public async Task Update(Drink drink)
    {
        await _mongoContext.Drinks.ReplaceOneAsync(u => u.id.Equals(drink.id), drink);
    }

    public async Task Delete(ObjectId id)
    {
        var filter = Builders<Drink>.Filter.Eq(u => u.id, id);
        await _mongoContext.Drinks.DeleteOneAsync(filter);
    }
}