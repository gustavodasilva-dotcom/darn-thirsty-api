using DarnThirsty.Application.Commands.Global;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Drink;

public class DrinkResponse : EntityResponse
{
    public DrinkResponse()
    {
        Type = new DrinkTypeResponse();
    }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("type")]
    public DrinkTypeResponse Type { get; set; }
}