using HelpDeskSystem.API.Enums;

namespace HelpDeskSystem.API.Models;

public class MessageModel
{
    public int IdMessage { get; set; }

    public int CalledId { get; set; }
    public CalledModel Called { get; set; }

    public string Content { get; set; }
    public DateTime DateHours { get; set; } = DateTime.UtcNow;

    public OriginMessageEnum Origin { get; set; }
}