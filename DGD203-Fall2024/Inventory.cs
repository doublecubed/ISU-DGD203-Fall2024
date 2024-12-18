namespace FirstGame;

public class Inventory
{
    #region REFERENCES
    
    private Game _game;
    
    #endregion
    
    #region VARIABLES
    
    private List<Item> _items;
    
    #endregion
    
    #region CONSTRUCTOR

    public Inventory(Game game)
    {
        _game = game;
        _items = new List<Item>();
    }
    
    #endregion
    
    #region METHODS

    public void LoadInventory()
    {
        // This will be used to load the inventory from a savegame.
    }
    
    #endregion
}

public enum ItemType
{
    Key,
    Currency
}
