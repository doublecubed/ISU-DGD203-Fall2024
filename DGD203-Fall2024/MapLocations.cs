namespace FirstGame;

public class MapLocations
{
    #region REFERENCES

    private GameMap _map;
    
    #endregion
    
    #region VARIABLES

    //                  key         value
    public Dictionary<Vector2Int, MapLocationData> Locations;
    
    #endregion
    
    #region CONSTRUCTOR
    public MapLocations(GameMap gameMap)
    {
        _map = gameMap;
        Locations = new Dictionary<Vector2Int, MapLocationData>();
        AddLocations();
    }
    
    #endregion
    
    #region METHODS

    private void AddLocations()
    {
        AddEmeraldCity();
    }

    #region Location Generation
    
    private void AddEmeraldCity()
    {
        Vector2Int coordinates = new Vector2Int {X = 0, Y = 0};
        
        MapLocationData emeraldCity = new MapLocationData();
        emeraldCity.Coordinates = coordinates;
        emeraldCity.Name = "Emerald City";
        emeraldCity.Description =
            "Emerald City sparkles like a jewel under a sky of shifting hues, " +
            "its towering spires wrapped in cascading ivy and enchanted lights " +
            "that dance with the whispers of magic. Bustling markets hum with the " +
            "clamor of traders hawking rare wares, while winding cobblestone " +
            "streets lead to hidden courtyards filled with secrets and song.";
        emeraldCity.IsAccessible = true;
        emeraldCity.IsInteractable = true;
        emeraldCity.Items = new Item[1];
        
        Item coin = GenerateCoin();
        emeraldCity.Items[0] = coin; 
        
        Interaction Merchant  = GenerateMerchant();
        emeraldCity.Interaction = Merchant;

        emeraldCity.AllowsTravel = new bool[] { true, false, true, true };
        
        Locations[coordinates] = emeraldCity;
    }

    #endregion
    
    #region Item Generation
    private Item GenerateCoin()
    {
        Item coin = new Item();
        coin.Type = ItemType.Currency;
        coin.Description = "This coin gleams in the sunlight. It must be very valuable";
        return coin;
    }
    
    #endregion
    
    #region Interaction Generation

    private Interaction GenerateMerchant()
    {
        string merchantDescription = "There is a merchant here. He looks at you with a sparkle in " +
                                     "his eyes, 'What would you like to buy?' he asks";

        string[] merchantChoices = new string[3];
        merchantChoices[0] = "Buy Apple (1 coin)";
        merchantChoices[1] = "Buy Sword (2 coins)";
        merchantChoices[2] = "Leave";

        string[] merchantResponses = new string[3];
        merchantResponses[0] = "Here is an apple, good person";
        merchantResponses[1] = "You don't have enough money, you scum";
        merchantResponses[2] = "Get to tha choppa";
        
    Interaction merchant = new MerchantInteraction(merchantDescription, merchantChoices, merchantResponses, _map);



        return merchant;
    }
    
    #endregion
    
    #endregion
}

public struct MapLocationData
{
    public Vector2Int Coordinates;
    public string Name;
    public string Description;
    public bool IsAccessible;
    public bool IsInteractable;
    public Interaction Interaction;
    public Item[] Items;
    public bool[] AllowsTravel;
}

