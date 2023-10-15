using DarnThirsty.Application.Commands.Drink;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Exceptions;
using DarnThirsty.Core.Repositories;
using MongoDB.Bson;

namespace DarnThirsty.Application.Handlers;

public class DrinkHandler : IDrinkHandler
{
    private readonly IDrinkRepository _drinkRepository;
    private readonly IDrinkTypeRepository _drinkTypeRepository;

    public DrinkHandler(IDrinkRepository drinkRepository,
                        IDrinkTypeRepository drinkTypeRepository)
    {
        _drinkRepository = drinkRepository;
        _drinkTypeRepository = drinkTypeRepository;
    }

    public async Task<IEnumerable<DrinkTypeResponse>> GetDrinkTypesAsync()
    {
        var types = await _drinkTypeRepository.GetAll();

        if (!types.Any())
            throw new NoContentException();

        return types.ToList().Select(t => new DrinkTypeResponse
        {
            Id = t.id.ToString(),
            Code = t.code,
            Name = t.name
        });
    }

    public async Task<IEnumerable<DrinkResponse>> GetDrinksAsync(int page, int quantity)
    {
        var drinks = await _drinkRepository.GetAll(skip: page, limit: quantity);

        if (!drinks.Any())
            throw new NoContentException();

        return drinks.ToList().Select(d => new DrinkResponse
        {
            Id = d.id.ToString(),
            Name = d.name,
            Image = d.image,
            Type = new DrinkTypeResponse
            {
                Id = d.type.id.ToString(),
                Code = d.type.code,
                Name = d.type.name
            }
        });
    }

    public async Task<DrinkContentResponse> GetDrinkAsync(string drinkId)
    {
        var _drinkId = ObjectId.Parse(drinkId);

        var drink = await _drinkRepository.Get(d => d.id == _drinkId) ??
            throw new NotFoundException(drinkId);

        return new DrinkContentResponse
        {
            Id = drink.id.ToString(),
            Name = drink.name,
            Image = drink.image,
            Type = new DrinkTypeResponse
            {
                Id = drink.type.id.ToString(),
                Code = drink.type.code,
                Name = drink.type.name
            },
            About = drink.about,
            Recipe = new RecipeResponse
            {
                Ingredients = drink.recipe.ingredients,
                Steps = drink.recipe.steps
            }
        };
    }
}