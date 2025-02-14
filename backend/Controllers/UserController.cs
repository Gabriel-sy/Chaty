using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers([FromQuery] string query)
    {
        var result = await _service.SearchUsersByUserName(query);

        return Ok(result.Data);
    }

    [HttpGet("chat")]
    public async Task<IActionResult> SendChatRequest([FromQuery] string receiver)
    {
        var email = HttpContext.User.Claims.Single(c => c.Type == "Name");

        var sender = await _service.FindUserByEmail(email.Value);
        
        var result = await _service.SendChatRequest(sender.Data, receiver);

        if (!result.IsSuccess)
        {
            return BadRequest("Não foi possível enviar a solicitação");
        }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByToken()
    {
        var email = HttpContext.User.Claims.Single(c => c.Type == "Name");

        var result = await _service.FindUserByEmail(email.Value);

        if (!result.IsSuccess)
        {
            return BadRequest("Não foi possível encontrar o usuário");
        }

        return Ok(result.Data);
    }

    [HttpPost("chat/refuse")]
    public async Task<IActionResult> RefuseChat([FromBody] string refusedUser)
    {
        var email = HttpContext.User.Claims.Single(c => c.Type == "Name");

        var refuser = await _service.FindUserByEmail(email.Value);

        var result = await _service.RefuseChatRequest(refuser.Data, refusedUser);

        return Ok();
    }
}