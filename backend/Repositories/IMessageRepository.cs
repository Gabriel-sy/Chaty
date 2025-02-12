using backend.Entities;

namespace backend.Repositories;

public interface IMessageRepository
{
    Task<List<Message>> GetAllMessagesFromAChat(Chat chat);
    Task DeleteMessage(Message message);
}