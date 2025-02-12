using backend.Entities;
using backend.Models;

namespace backend.Services;

public interface IChatService
{
    Task<ResultViewModel> CreateChat(ChatInputModel model);
    Task<ResultViewModel<List<ChatViewModel>>> GetUserChatsWithMessages(User user);
}