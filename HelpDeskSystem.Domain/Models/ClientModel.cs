namespace HelpDeskSystem.API.Models;

public class ClientModel
{
    public int IdClient { get; private set; }
    public string Name { get; private set; } = default!;
    public string NumberClient { get; private set; } = default!;
    
    public ICollection<CalledModel> Calleds { get; private set; }
    
    public ClientModel(){}

    public ClientModel(int idClient, string name, string numberClient, ICollection<CalledModel> called)
    {
        IdClient = idClient;
        Name = name;
        NumberClient = numberClient;
        Calleds = called;
    }
}