using DarnThirsty.Core.Entities;
using MongoDB.Bson;

namespace DarnThirsty.Core.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll(int skip = 0, int limit = 50);
    Task<User> GetById(ObjectId id);
    Task<bool> Exists(string email);
    Task Save(User user);
    Task Update(User user);
    Task Delete(ObjectId id);
}