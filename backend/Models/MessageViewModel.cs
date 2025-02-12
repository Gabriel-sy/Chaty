namespace backend.Models;

public class MessageViewModel
{
    public MessageViewModel(string messageText, bool seen)
    {
        MessageText = messageText;
        Seen = seen;
    }

    public string MessageText { get; private set; }
    public bool Seen { get; private set; }
}