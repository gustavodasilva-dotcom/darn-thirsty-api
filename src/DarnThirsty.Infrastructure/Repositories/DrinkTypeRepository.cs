using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Repositories;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Repositories;

public class DrinkTypeRepository : IDrinkTypeRepository
{
    private readonly IMongoContext _mongoContext;

    public DrinkTypeRepository(IMongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }

    public async Task<IEnumerable<DrinkType>> GetAll(int skip = 0, int limit = 50)
    {
        return await _mongoContext.DrinkTypes.Find(u => true).Skip(skip).Limit(limit).ToListAsync();
    }
}