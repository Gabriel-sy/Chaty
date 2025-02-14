using backend.Entities;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ChatyDbContext _context;

    public UserRepository(ChatyDbContext context)
    {
        _context = context;
    }

    public async Task<User?> FindUserByUserName(string username)
    {
       var user = 
           await _context.Users.SingleOrDefaultAsync(u => u.UserName == username && !u.IsDeleted);

       return user;
    }

    public async Task<List<string>> FindUsersByUserName(string query)
    {
        var users =
            await _context.Users.Where(u => EF.Functions.Like(u.UserName, $"%{query}%"))
                .ToListAsync();

        return users.Select(u => u.UserName).ToList();
    }
    
    public async Task SendChatRequest(User receiver, string sender)
    {
        receiver.AddChatRequest(sender);

        _context.Users.Update(receiver);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

        return user;
    }
}