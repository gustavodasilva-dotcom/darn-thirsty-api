using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DarnThirsty.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoContext _mongoContext;

    public UserRepository(IMongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }

    public async Task<IEnumerable<User>> GetAll(int skip = 0, int limit = 50)
    {
        return await _mongoContext.Users.Find(u => true).Skip(skip).Limit(limit).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> expression)
    {
        return await _mongoContext.Users.Find(expression).ToListAsync();
    }

    public Task<User> Get(Expression<Func<User, bool>> expression)
    {
        return _mongoContext.Users.FindSync(expression).FirstOrDefaultAsync();
    }

    public Task<bool> Exists(string email)
    {
        return _mongoContext.Users.FindSync(u => u.email.Equals(email)).AnyAsync();
    }

    public Task<bool> Exists(Expression<Func<User, bool>> expression)
    {
        return _mongoContext.Users.FindSync(expression).AnyAsync();
    }

    public async Task Save(User user)
    {
        await _mongoContext.Users.InsertOneAsync(user);
    }

    public async Task Update(User user)
    {
        await _mongoContext.Users.ReplaceOneAsync(u => u.id.Equals(user.id), user);
    }

    public async Task Delete(ObjectId id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.id, id);
        await _mongoContext.Users.DeleteOneAsync(filter);
    }
}