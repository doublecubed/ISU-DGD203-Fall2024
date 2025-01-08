namespace FirstGame;

public class Interaction
{
    public string Description { get; private set; }
    public string[] Choices { get; private set; }

    public Interaction(string description, string[] choices)
    {
        Description = description;
        Choices = choices;
    }

    public void Choose()
    {
        Console.WriteLine(Description);
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine($"{i+1}) {Choices[i]}");
        }
    }
}