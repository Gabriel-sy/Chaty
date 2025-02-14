namespace backend.Entities;

public class Chat : BaseEntity 
{
    protected Chat() 
    {
        UserChats = [];
    }
    
    //t é apenas para diferenciar do construtor acima, não tem uso. 
    public Chat(string? t) 
    {
        UserChats = [];
    }

    public List<UserChat> UserChats { get; private set; }

    public void addUserChat(UserChat userChat)
    {
        UserChats.Add(userChat);
    }
    
    
}