namespace backend.Entities;

public class User : BaseEntity 
{
    protected User() 
    {
        UserChats = [];
    }

    public User(string email, string userName, string password, string? biography)
    {
        Email = email;
        UserName = userName;
        Password = password;
        Biography = biography ?? null;
        UserChats = [];
        ChatRequests = [];
    }

    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string? Biography { get; private set; }
    public byte[]? ProfilePicture { get; private set; }
    public List<string> ChatRequests { get; private set; }
    public List<UserChat> UserChats { get; private set; }

    public void UpdateProfile(string? biography = null, byte[]? profilePicture = null)
    {
        Biography = biography ?? Biography;
        ProfilePicture = profilePicture ?? ProfilePicture;
    }

    public void AddChatRequest(string userName)
    {
        ChatRequests.Add(userName);
    }
}