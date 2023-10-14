using DarnThirsty.Core.Entities;
using MongoDB.Driver;

namespace DarnThirsty.Core.Data;

public interface IMongoContext
{
    IMongoCollection<User> Users { get; }

    IMongoCollection<DrinkType> DrinkTypes { get; }

    IMongoCollection<Drink> Drinks { get; }
}