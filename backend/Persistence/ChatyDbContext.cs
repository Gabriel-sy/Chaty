using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence;

public class ChatyDbContext : DbContext
{
    public ChatyDbContext(DbContextOptions<ChatyDbContext> options) : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Message>(e =>
            {
                e.HasKey(m => m.Id);
                e.HasOne(m => m.UserChat)
                    .WithMany()
                    .HasForeignKey(m => new { m.UserId, m.ChatId })
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasMany(u => u.UserChats)
                    .WithOne(u => u.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Chat>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasMany(c => c.UserChats)
                    .WithOne(u => u.Chat)
                    .HasForeignKey(u => u.ChatId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<UserChat>(e =>
            {
                //Chave primária composta, evita duplicatas.
                e.HasKey(u => new { u.UserId, u.ChatId });

                e.HasOne(u => u.User)
                    .WithMany(u => u.UserChats)
                    .HasForeignKey(u => u.UserId);

                e.HasOne(u => u.Chat)
                    .WithMany(c => c.UserChats)
                    .HasForeignKey(u => u.ChatId);
            });
    }
}