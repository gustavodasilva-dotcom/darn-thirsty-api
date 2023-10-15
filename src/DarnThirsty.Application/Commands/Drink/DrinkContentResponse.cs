using DarnThirsty.Application.Commands.Global;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Drink;

public class DrinkContentResponse : EntityResponse
{
    public DrinkContentResponse()
    {
        Type = new DrinkTypeResponse();
        Recipe = new RecipeResponse();
    }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("type")]
    public DrinkTypeResponse Type { get; set; }

    [JsonProperty("about")]
    public string[] About { get; set; }

    [JsonProperty("recipe")]
    public RecipeResponse Recipe { get; set; }
}