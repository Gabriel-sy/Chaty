using backend.Entities;

namespace backend.Repositories;

public interface IChatRepository
{
    Task<Chat?> CreateChat(User user1, User user2);
    Task DeleteChat(Chat chat);
    Task<string[]> FindAllUserChats(User user);
    Task<Chat?> FindChatByUsers(User user1, User user2);
}