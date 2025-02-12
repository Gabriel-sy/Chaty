using backend.Entities;

namespace backend.Models;

public class RegisterInputModel
{
    public RegisterInputModel(string email, string password, string userName, string? biography)
    {
        Email = email;
        Password = password;
        UserName = userName;
        Biography = biography ?? null;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string? Biography { get; set; }

    public User FromEntity()
    {
        return new User(Email, UserName, Password, Biography ?? null);
    }
}