using DarnThirsty.Core.Entities;

namespace DarnThirsty.Core.Repositories;

public interface IDrinkTypeRepository
{
    Task<IEnumerable<DrinkType>> GetAll(int skip = 0, int limit = 50);
}