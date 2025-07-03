using HelpDeskSystem.API.Models;

namespace DefaultNamespace;

public class CalledRequestDto
{
    public int IdCalled { get; set; }
    public int ClientId { get; set; }
    
    public int TechnicalId { get; set; }
    public string Technical { get; set; } = string.Empty;

    public DateTime? DateClose { get; set; }
    public string Status { get; set; } = "Open";
}