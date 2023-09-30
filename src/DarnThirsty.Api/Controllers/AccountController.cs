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

    [HttpGet("auth")]
    public async Task<IActionResult> Get([FromBody] FirstAccessRequest request)
    {
        await _accountHandler.ExecuteFirstAccess(request);
        return Ok();
    }
}
