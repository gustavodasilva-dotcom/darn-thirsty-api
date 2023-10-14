using DarnThirsty.Application.Commands;
using DarnThirsty.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DarnThirsty.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountHandler _accountHandler;

    public AccountController(ILogger<AccountController> logger,
                             IAccountHandler accountHandler)
    {
        _logger = logger;
        _accountHandler = accountHandler;
    }

    [HttpPost("register/first-access")]
    [ProducesResponseType(201)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> RegisterFirstAccess([FromBody] UserAccountRequest request)
    {
        await _accountHandler.ExecuteFirstAccessAsync(request);
        return StatusCode(201);
    }

    [HttpPost("auth")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Auth([FromBody] UserAccountRequest request)
    {
        return Ok(await _accountHandler.ExecuteAuthAsync(request));
    }
}
