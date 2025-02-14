using backend.Entities;

namespace backend.Models;

public class ChatViewModel
{
    public ChatViewModel(string userName)
    {
        UserName = userName;
    }

    //TODO: Ultima mensagem, data da ultima mensagem
    public string UserName { get; set; }
}