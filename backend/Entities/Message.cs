using backend.Models;

namespace backend.Entities;

public class Message : BaseEntity 
{
    protected Message(int userId, int chatId)
    {
        UserId = userId;
        ChatId = chatId;
    }
    
    public Message(string messageText, UserChat userChat, int userId, int chatId)
    {
        MessageText = messageText;
        UserChat = userChat;
        UserId = userId;
        ChatId = chatId;
        Seen = false;
    }

    public string MessageText { get; private set; }
    public int UserId { get; private set; }
    public int ChatId { get; private set; }
    public UserChat UserChat { get; private set; }
    public bool Seen { get; private set; }
    
    public void MarkAsSeen() => Seen = true;

    public MessageViewModel FromEntity()
    {
        return new MessageViewModel(MessageText, Seen);
    }
}