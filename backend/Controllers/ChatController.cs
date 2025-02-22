﻿using backend.Models;
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
    public async Task<IActionResult> GetAllChatsFromUser()
    {
        var email = HttpContext.User.Claims.Single(c => c.Type == "Name");
        
        var result = await _service.GetUserChats(email.Value);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatInputModel users)
    {
        var result = await _service.CreateChat(users.User1, users.User2);

        if (!result.IsSuccess)
        {
            return BadRequest("Não foi possível criar o chat");
        }

        return Created();
    }
}