using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands;

public class UserRequest : UserAccountRequest
{
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; }

    [Required]
    [JsonProperty("active")]
    public bool Active { get; set; }
}