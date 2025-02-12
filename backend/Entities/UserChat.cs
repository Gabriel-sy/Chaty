namespace backend.Entities;

public class UserChat
{
    public UserChat(int userId, User user, int chatId, Chat chat)
    {
        UserId = userId;
        User = user;
        ChatId = chatId;
        Chat = chat;
    }

    public int UserId { get; private set; }
    public User User { get; private set; }

    public int ChatId { get; private set; }
    public Chat Chat { get; private set; }
}