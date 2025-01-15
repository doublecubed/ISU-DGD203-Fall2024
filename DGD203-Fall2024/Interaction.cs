namespace FirstGame;

public class Interaction
{
    public string Description { get; private set; }
    public string[] Choices { get; private set; }

    public string[] Responses { get; private set; }

    protected int _choiceIndex;
    
    public Interaction(string description, string[] choices, string[] responses)
    {
        Description = description;
        Choices = choices;
        Responses = responses;
    }

    public virtual void Choose()
    {
        Console.WriteLine(Description);
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine($"{i+1}) {Choices[i]}");
        }
        string response = Console.ReadLine();
        _choiceIndex = int.Parse(response) - 1; 
        
        Console.WriteLine(Responses[_choiceIndex]);
    }
}