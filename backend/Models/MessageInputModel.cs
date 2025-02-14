using backend.Entities;

namespace backend.Models;

public class MessageInputModel
{
    public string MessageText { get; set; }
    public int ChatId { get; set; }
}