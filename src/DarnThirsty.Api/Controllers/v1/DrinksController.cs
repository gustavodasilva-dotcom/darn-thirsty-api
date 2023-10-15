using System.ComponentModel.DataAnnotations;
using DarnThirsty.Application.Commands.Drink;
using DarnThirsty.Application.Commands.Global;
using DarnThirsty.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DarnThirsty.Api.Controllers.v1;

[ApiController]
[Route("v1/[controller]")]
[Produces("application/json")]
public class DrinksController : ControllerBase
{
    private readonly ILogger<DrinksController> _logger;
    private readonly IDrinkHandler _drinkHandler;

    public DrinksController(ILogger<DrinksController> logger,
                            IDrinkHandler drinkHandler)
    {
        _logger = logger;
        _drinkHandler = drinkHandler;
    }

    [HttpGet("types")]
    [ProducesResponseType(typeof(IEnumerable<DrinkTypeResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDrinkTypesAsync()
    {
        return Ok(await _drinkHandler.GetDrinkTypesAsync());
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DrinkResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDrinksAsync(
        [FromQuery, Range(0, int.MaxValue)] int page = 0, [FromQuery, Range(1, 50)] int quantity = 5)
    {
        return Ok(await _drinkHandler.GetDrinksAsync(page, quantity));
    }

    [HttpGet("{drinkId}")]
    [ProducesResponseType(typeof(DrinkContentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDrinksAsync(string drinkId)
    {
        return Ok(await _drinkHandler.GetDrinkAsync(drinkId));
    }
}