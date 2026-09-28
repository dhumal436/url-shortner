using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ShortLi.Application.Services.Authentication;

namespace ShortLi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    IAuthService _authService;
    public AuthenticationController(IAuthService authService){
        _authService=authService;
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] Contracts.Authentication.RegisterRequest registerRequest)
    {
        return Ok( _authService.Register(registerRequest));
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Contracts.Authentication.LoginRequest loginRequest)
    {
        return Ok(_authService.Login(loginRequest));
    }
}