using backend.Models;

namespace backend.Services;

public interface IUserService
{
    Task<ResultViewModel<List<string>>> SearchUsersByUserName(string query);
}