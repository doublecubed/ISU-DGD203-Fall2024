// This class will parse any given command
// and apply that command.

namespace FirstGame;

public class Commands
{
    #region REFERENCES
    
    private Game _game;
    private GameMap _map;
    private SaveManager _saveManager;
    
    #endregion
    
    #region CONSTRUCTOR
    public Commands(Game game, GameMap map, SaveManager saveManager)
    {
        _game = game;
        _map = map;
        _saveManager = saveManager;
    }
    
    #endregion
    
    #region METHODS
    
    public void ExecuteCommand(string command)
    {
        switch (command.ToLower())
        {
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

    #region Map Commands
    
    private void MoveCommand(Direction direction)
    {
        _map.MovePlayer(direction);
        Vector2Int playerPosition = _map.GetPlayerPosition();
        Console.WriteLine($"You are at {playerPosition.X}, {playerPosition.Y}");
        Console.WriteLine(CurrentLocationDescription());
    }
    
    private string CurrentLocationDescription()
    {
        GameMap.Location currentLocation = _map.GetCurrentLocation();
        return currentLocation.Description;
    }
    
    #endregion
    
    #region Game Commands

    private void SaveGame()
    {
        string savePath = SavePath();
        string saveContent = "I'm saving this game!";

        File.WriteAllText(savePath, saveContent);

    }

    private void LoadGame()
    {
        string savePath = SavePath();
    }

    private string SavePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string fullPath = projectDirectory + @"\save.sgf";

        return fullPath;
    }
    
    #endregion
    
    #endregion
}