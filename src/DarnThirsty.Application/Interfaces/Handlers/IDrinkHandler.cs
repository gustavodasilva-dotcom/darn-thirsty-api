using DarnThirsty.Application.Commands.Drink;

namespace DarnThirsty.Application.Interfaces.Handlers;

public interface IDrinkHandler
{
    Task<IEnumerable<DrinkTypeResponse>> GetDrinkTypesAsync();
    Task<IEnumerable<DrinkResponse>> GetDrinksAsync(int page, int quantity);
    Task<DrinkContentResponse> GetDrinkAsync(string drinkId);
}