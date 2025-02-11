namespace backend.Entities;

public class Chat : BaseEntity 
{
    protected Chat() 
    {
        UserChats = [];
    }

    public List<UserChat> UserChats { get; private set; }
}