using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DarnThirsty.Application.Commands;

public class ExceptionResponse
{
    [Required]
    [JsonProperty("status_code")]
    public int status_code { get; set; }

    [Required]
    [JsonProperty("message")]
    public string message { get; set; }
}