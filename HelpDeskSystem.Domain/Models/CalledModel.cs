using HelpDeskSystem.API.Enums;

namespace HelpDeskSystem.API.Models;

public class CalledModel
{
    public int IdCalled { get; private set; }

    public int ClientId { get; private set; }
    public ClientModel Client { get; private set; }

    public int TechnicalId { get; private set; }
    public string Technical { get; private set; } = string.Empty;

    public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
    public DateTime? DateClose { get; private set; }

    public CalledStatusEnum Status { get; private set; } = CalledStatusEnum.Open;

    public ICollection<MessageModel> Messages { get; private set; }
    
    
    public CalledModel(){}

    public CalledModel(int idCalled, int clientId, int technicalId, string technical, DateTime? dateClose, CalledStatusEnum status, ICollection<MessageModel> messages)
    {
        IdCalled = idCalled;
        ClientId = clientId;
        TechnicalId = technicalId;
        Technical = technical;
        DateClose = dateClose;
        Status = status;
        Messages = messages;
    }
}