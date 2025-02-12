using backend.Entities;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ChatyDbContext _context;

    public MessageRepository(ChatyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetAllMessagesFromAChat(Chat chat)
    {
        return await _context.Messages
            .Where(m => m.ChatId == chat.Id)
            .ToListAsync();
    }

    public async Task DeleteMessage(Message message)
    {
        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
    }
}