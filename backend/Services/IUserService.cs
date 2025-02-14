using backend.Entities;
using backend.Models;

namespace backend.Services;

public interface IUserService
{
    Task<ResultViewModel<List<SearchUserViewModel>>> SearchUsersByUserName(string query);
    Task<ResultViewModel> SendChatRequest(User sender, string receiver);
    Task<ResultViewModel<User?>> FindUserByEmail(string email);
    Task<ResultViewModel> RefuseChatRequest(User refuser, string nameToRemove);
}