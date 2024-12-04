namespace FirstGame
{
    public class Player
    {
        public string? Name { get; private set; }
        
        public Player(string? name = "John Doe")
        {
            Name = name;
        }

        public void Initialize(string? name)
        {
            Name = name;
        }
    }
}