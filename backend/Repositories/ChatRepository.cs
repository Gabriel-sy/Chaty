using backend.Entities;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ChatyDbContext _context;

    public ChatRepository(ChatyDbContext context)
    {
        _context = context;
    }

    public async Task<Chat?> CreateChat(User user1, User user2)
    {
        var chat = new Chat("");

        var userChat1 = new UserChat(user1.Id, user1, chat.Id, chat);
        var userChat2 = new UserChat(user2.Id, user2, chat.Id, chat);
        
        chat.addUserChat(userChat1);
        chat.addUserChat(userChat2);

        await _context.Chats.AddAsync(chat);
        await _context.UserChats.AddAsync(userChat1);
        await _context.UserChats.AddAsync(userChat2);
        await _context.SaveChangesAsync();

        return chat;
    }

    public async Task DeleteChat(Chat chat)
    {
        var checkExists = await _context.Chats.SingleOrDefaultAsync(c => c.Id == chat.Id);

        if (checkExists is not null)
        {
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<List<Chat>> FindAllUserChats(User user)
    {
        var userChats = await _context.UserChats
            .Where(uc => uc.UserId == user.Id)
            .Include(userChat => userChat.Chat)
            .ToListAsync();

        return userChats.Select(userChat => userChat.Chat).ToList();
    }

    public async Task<Chat?> FindChatByUsers(User user1, User user2)
    {
        return await _context.UserChats
            .Where(uc => uc.UserId == user1.Id || uc.UserId == user2.Id) 
            .GroupBy(uc => uc.ChatId)
            .Where(g => g.Count() == 2) 
            .Select(g => g.First().Chat)
            .FirstOrDefaultAsync();
    }
}