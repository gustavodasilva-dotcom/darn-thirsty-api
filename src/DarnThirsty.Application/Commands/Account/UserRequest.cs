using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands.Account;

public class UserRequest
{
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; }

    [Required]
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [Required]
    [JsonProperty("password")]
    public string Password { get; set; }

    [Required]
    [JsonProperty("active")]
    public bool Active { get; set; }
}