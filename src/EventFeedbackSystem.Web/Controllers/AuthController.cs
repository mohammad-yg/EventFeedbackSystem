using EventFeedbackSystem.Application.Shared.Auth;
using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EventFeedbackSystem.Web.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [ActionName("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginInput input)
    {
        var result = await _authenticationService.LoginAsync(input);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }

    [HttpPost]
    [ActionName("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterInput input)
    {
        var result = await _authenticationService.RegisterAsyn(input);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
