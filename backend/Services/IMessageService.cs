using backend.Models;

namespace backend.Services;

public interface IMessageService
{
    Task<ResultViewModel<List<MessageViewModel>>> GetAllMessagesFromAChat(ChatInputModel model);
    Task<ResultViewModel> DeleteMessage(MessageInputModel model);
}