using backend.Entities;

namespace backend.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUserName(string username);
    Task<List<string>> FindUsersByUserName(string query);
}