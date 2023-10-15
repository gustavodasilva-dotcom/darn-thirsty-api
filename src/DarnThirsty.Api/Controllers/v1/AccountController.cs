using DarnThirsty.Application.Commands.Account;
using DarnThirsty.Application.Commands.Global;
using DarnThirsty.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarnThirsty.Api.Controllers.v1;

[ApiController, Authorize]
[Route("v1/[controller]")]
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

    [HttpPost("register/first-access"), AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterFirstAccessAsync([FromBody] AccountRequest request)
    {
        await _accountHandler.ExecuteFirstAccessAsync(request);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("auth"), AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AuthAsync([FromBody] AccountRequest request)
    {
        return Ok(await _accountHandler.ExecuteAuthAsync(request));
    }

    [HttpPut("update/{userId}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromRoute] string userId, [FromBody] UserRequest request)
    {
        return Ok(await _accountHandler.ExecuteUpdateAsync(userId, request));
    }
}
