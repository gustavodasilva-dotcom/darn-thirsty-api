using DarnThirsty.Application.Commands;
using DarnThirsty.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DarnThirsty.Api.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<IActionResult> RegisterFirstAccess([FromBody] UserAccountRequest request)
    {
        try
        {
            await _accountHandler.ExecuteFirstAccessAsync(request);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Auth([FromBody] UserAccountRequest request)
    {
        try
        {
            return Ok(await _accountHandler.ExecuteAuthAsync(request));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
