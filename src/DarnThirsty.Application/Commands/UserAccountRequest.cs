using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DarnThirsty.Application.Commands;

public class UserAccountRequest
{
    [Required]
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [Required]
    [JsonProperty("password")]
    public string Password { get; set; }
}