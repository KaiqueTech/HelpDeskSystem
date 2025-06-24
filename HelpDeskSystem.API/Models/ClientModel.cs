namespace HelpDeskSystem.API.Models;

public class ClientModel
{
    public int IdClient { get; private set; }
    public string Name { get; private set; }
    public string NumBerClient { get; private set; }
    
    public ICollection<object> Called { get; private set; }
    
    public ClientModel(){}

    public ClientModel(int idClient, string name, string numberClient, ICollection<object> called)
    {
        IdClient = idClient;
        Name = name;
        NumBerClient = numberClient;
        Called = called;
    }
}