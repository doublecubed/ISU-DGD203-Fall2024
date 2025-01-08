// This class will parse any given command
// and apply that command.

namespace FirstGame;

public class Commands
{
    #region REFERENCES

    private Player _player;
    private Game _game;
    private GameMap _map;
    private SaveManager _saveManager;
    
    #endregion
    
    #region INITIALIZATION
    public Commands(Game game)
    {
        _game = game;
    }

    public void Initialize(GameMap map, SaveManager saveManager, Player player)
    {
        _map = map;
        _saveManager = saveManager;
        _player = player;
    }
    
    #endregion
    
    #region METHODS
    
    public void ExecuteCommand(string command)
    {
        switch (command.ToLower())
        {
            // Player Commants
            case "who":
                PlayerWho();
                break;
            case "look":
                LookCommand();
                break;
            case "interact":
                InteractCommand();
                break;
            
            // Map Commands
            case "east":
                MoveCommand(Direction.East);
                break;
            case "north":
                MoveCommand(Direction.North);
                break;
            case "west":
                MoveCommand(Direction.West);
                break;
            case "south":
                MoveCommand(Direction.South);
                break;
            case "e":
                MoveCommand(Direction.East);
                break;
            case "n":
                MoveCommand(Direction.North);
                break;
            case "w":
                MoveCommand(Direction.West);
                break;
            case "s":
                MoveCommand(Direction.South);
                break;

            
            // Inventory Commands
            
            // Multiple Choices
            
            // Game Commands
            case "exit":
                _game.GiveExitCommand();
                break;
            case "save":
                Console.WriteLine("Saving...");
                SaveGame();
                break;
            case "load":
                Console.WriteLine("Loading...");
                LoadGame();
                break;
            
            // Default
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }

    #region Player Commands

    private void PlayerWho()
    {
        Console.WriteLine($"You are {_player.Name}!");
    }
    
    private void LookCommand()
    {
        Console.WriteLine(CurrentLocationDescription());
    }

    private void InteractCommand()
    {
        _map.InteractWithCurrentLocation();
    }
    
    #endregion
    
    #region Map Commands
    
    private void MoveCommand(Direction direction)
    {
        _map.MovePlayer(direction);
        
        Vector2Int playerPosition = _map.GetPlayerPosition();
        Console.WriteLine($"You are at {playerPosition.X}, {playerPosition.Y}");
        Console.WriteLine($"You are in {CurrentLocationName()}");
    }

    private string CurrentLocationName()
    {
        string currentLocationName = _map.GetCurrentLocationName();
        return currentLocationName;
    }
    
    private string CurrentLocationDescription()
    {
        string currentLocationDescription = _map.GetCurrentLocationDescription();
        return currentLocationDescription;
    }
    
    #endregion
    
    #region Game Commands

    private void SaveGame()
    {
        _saveManager.SaveGame();
    }

    private void LoadGame()
    {
        _saveManager.LoadGame();
    }
    
    #endregion
    
    #endregion
}