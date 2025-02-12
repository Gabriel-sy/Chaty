using backend.Entities;

namespace backend.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUserName(string username);
}