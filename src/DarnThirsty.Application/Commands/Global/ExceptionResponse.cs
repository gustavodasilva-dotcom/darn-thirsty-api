using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Global;

public class ExceptionResponse
{
    [JsonProperty("status_code")]
    public int status_code { get; set; }

    [JsonProperty("message")]
    public string message { get; set; }
}