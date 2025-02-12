using backend.Entities;
using backend.Models;

namespace backend.Services;

public class ChatService : IChatService
{
    public Task<ResultViewModel> CreateChat(ChatInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResultViewModel<List<ChatViewModel>>> GetUserChatsWithMessages(User user)
    {
        throw new NotImplementedException();
    }
}