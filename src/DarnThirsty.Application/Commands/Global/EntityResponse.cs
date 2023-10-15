using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Global;

public class EntityResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }
}