using DarnThirsty.Core.Entities;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace DarnThirsty.Core.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll(int skip = 0, int limit = 50);
    Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> expression);
    Task<User> Get(Expression<Func<User, bool>> expression);
    Task<bool> Exists(string email);
    Task Save(User user);
    Task Update(User user);
    Task Delete(ObjectId id);
}