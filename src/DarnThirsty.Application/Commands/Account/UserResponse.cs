using DarnThirsty.Application.Commands.Global;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Account;

public class UserResponse : EntityResponse
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }
}