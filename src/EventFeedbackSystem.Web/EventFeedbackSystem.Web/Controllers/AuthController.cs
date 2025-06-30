using EventFeedbackSystem.Application.Shared.Auth;
using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EventFeedbackSystem.Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginInput input)
    {
        var result = await _authenticationService.LoginAsync(input);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data); 
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterInput input)
    {
        var result = await _authenticationService.RegisterAsyn(input);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
