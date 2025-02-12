using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/auth")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterInputModel model)
    {
        var result = await _service.Register(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Created();
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginInputModel model)
    {
        var result = await _service.Login(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(new { jwt = result.Data });
    }
}