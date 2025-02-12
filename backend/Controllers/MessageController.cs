using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/message")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;

    public MessageController(IMessageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMessagesFromAChat([FromBody] ChatInputModel model)
    {
        var result = await _service.GetAllMessagesFromAChat(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Data);
    }
}