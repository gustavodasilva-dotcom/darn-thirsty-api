using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Drink;

public class RecipeResponse
{
    [JsonProperty("ingredients")]
    public string[] Ingredients { get; set; }

    [JsonProperty("steps")]
	public string[] Steps { get; set; }
}