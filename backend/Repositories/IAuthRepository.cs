using backend.Entities;
using backend.Models;

namespace backend.Repositories;

public interface IAuthRepository
{
    Task<User?> Register(User user);
    Task<User?> Login(string email, string password);
    // Task<User?> GetUserByUserName(string username);
    // Task<User?> GetUserByEmail(string email);
}