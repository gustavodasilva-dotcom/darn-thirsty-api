using DarnThirsty.Application.Commands.Global;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Drink;

public class DrinkTypeResponse : EntityResponse
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}