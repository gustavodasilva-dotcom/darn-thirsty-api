using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DarnThirsty.Application.Commands;

public class FirstAccessRequest
{
    [Required]
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [Required]
    [JsonProperty("password")]
    public string Password { get; set; }
}