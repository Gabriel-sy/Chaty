using backend.Entities;

namespace backend.Models;

public class MessageInputModel
{
    public string MessageText { get; set; }
    public Chat Chat { get; set; }
}