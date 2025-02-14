using backend.Entities;

namespace backend.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUserName(string username);
    Task<List<string>> FindUsersByUserName(string query);
    Task SendChatRequest(User receiver, string sender);
    Task<User?> FindUserByEmail(string email);
    Task RefuseChatRequest(User refuser, string nameToRemove);
}