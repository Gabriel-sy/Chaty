using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/chat")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatService _service;

    public ChatController(IChatService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChatsFromUser([FromQuery] string username)
    {
        var result = await _service.GetUserChats(username);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] ChatInputModel model)
    {
        var result = await _service.CreateChat(model);

        if (!result.IsSuccess)
        {
            return BadRequest("Não foi possível criar o chat");
        }

        return Created();
    }
}