using DarnThirsty.Core.Entities;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace DarnThirsty.Core.Repositories;

public interface IDrinkRepository
{
	Task<IEnumerable<Drink>> GetAll(int skip = 0, int limit = 50);
	Task<IEnumerable<Drink>> GetAll(Expression<Func<Drink, bool>> expression);
	Task<Drink> Get(Expression<Func<Drink, bool>> expression);
	Task Save(Drink drink);
	Task Update(Drink drink);
	Task Delete(ObjectId id);
}