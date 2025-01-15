namespace FirstGame;

public class MerchantInteraction : Interaction
{
    private GameMap _map;
    
    public MerchantInteraction(string description, string[] choices, string[] responses, GameMap map) 
        : base(description, choices, responses)
    {
        _map = map;
    }

    public override void Choose()
    {
        base.Choose();
        ExecuteChoice();
    }

    private void ExecuteChoice()
    {
        if (_choiceIndex == 1) _map.MovePlayer(Direction.North);
    }
}