using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands;

public class FirstAccessRequest
{
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
}