using backend.Entities;
using backend.Models;

namespace backend.Services;

public interface IChatService
{
    Task<ResultViewModel> CreateChat(string username1, string username2);
    Task<ResultViewModel<List<ChatViewModel>>> GetUserChats(string email);
}