using Microsoft.AspNetCore.Mvc;

namespace DarnThirsty.Api.Controllers.v1;

[ApiController]
[Route("v1/[controller]")]
[Produces("application/json")]
public class DrinksController : ControllerBase
{
    private readonly ILogger<DrinksController> _logger;

    public DrinksController(ILogger<DrinksController> logger)
    {
        _logger = logger;
    }
}