using backend.Entities;

namespace backend.Models;

public class ChatViewModel
{
    public ChatViewModel(User user1, User user2, List<Message> messages)
    {
        User1 = user1;
        User2 = user2;
        Messages = messages;
    }

    public User User1 { get; set; }
    public User User2 { get; set; }
    public List<Message> Messages { get; set; }
}