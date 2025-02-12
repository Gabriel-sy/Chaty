using backend.Entities;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ChatyDbContext _context;

    public AuthRepository(ChatyDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> Register(User user)
    {
        var UserExists = 
            await _context.Users.AnyAsync(u => u.UserName == user.UserName && !u.IsDeleted);

        if (UserExists)
        {
            return null;
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> Login(string email, string password)
    {
        var user =
            await _context.Users.SingleOrDefaultAsync
                (u => u.Email == email && u.Password == password && !u.IsDeleted);

        return user;
    }

    // public async Task<User?> GetUserByUserName(string username)
    // {
    //     var user = 
    //         await _context.Users.SingleOrDefaultAsync(u => u.UserName == username && !u.IsDeleted);
    //
    //     return user;
    // }
    //
    // public async Task<User?> GetUserByEmail(string email)
    // {
    //     var user = 
    //         await _context.Users.SingleOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
    //
    //     return user;
    // }
}