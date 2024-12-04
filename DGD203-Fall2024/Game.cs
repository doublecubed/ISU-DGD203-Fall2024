using FirstGame.Engines;

namespace FirstGame;

public class Game
{
    #region VARIABLES
    
    #region Constant Variables
    
    private const int MapWidth = 5;
    private const int MapHeight = 5;

    private const string NewCommandSeparator = "--------------------------";
    
    #endregion
    
    public static readonly Vector2Int DefaultStartingCoordinates = new Vector2Int { X = 0, Y = 0 };
    
    private Player _player;
    private GameMap _map;

    // GameState variables
    private bool _isRunning;
    
    // Command variables
    private string _currentCommand;
    
    #endregion
    
    #region CONSTRUCTOR
    
    public Game()
    {
        _player = new Player();
    }

    #endregion
    
    #region METHODS
    
    #region Starting Methods
    
    public void StartGame()
    {
        GenerateMap();
        GetPlayerName();
        StartGameLoop();

        GameLoop();
        
        // This will run only after the game ends
    }

    private void GenerateMap()
    {
        _map = new GameMap(MapWidth, MapHeight, DefaultStartingCoordinates);
    }
    
    private void GetPlayerName()
    {
        Console.WriteLine("The game started. Please give me your name:");
        string playerName = Console.ReadLine();
        if (playerName == "" || playerName == null)
        {
            Console.WriteLine("There is no name here! You are dead to me");
            playerName = "Dead2Me";
        }


        _player.Initialize(playerName);

        Console.WriteLine($"Welcome, {_player.Name}, to this game");
    }
    
    #endregion
    
    #region Game Loop Methods

    private void StartGameLoop()
    {
        _isRunning = true;
    }

    private void GameLoop()
    {
        while (_isRunning)
        {
            ReceiveCommand();
            ApplyCommand();
            CheckIfGameOver();
        }
    }

    private void ReceiveCommand()
    {
        Console.WriteLine(NewCommandSeparator);
        Console.WriteLine("What do you want to do?");
        _currentCommand = Console.ReadLine();
    }

    private void ApplyCommand()
    {
        if (ExitCommandGiven())
        {
            _isRunning = false;
            return;
        }
        
        ProcessMapCommand();
        ProcessInventoryCommand();
    }

    private void CheckIfGameOver()
    {
        
    }

    private string CurrentLocationDescription()
    {
        GameMap.Location currentLocation = _map.GetCurrentLocation();
        return currentLocation.Description;
    }

    private bool ExitCommandGiven()
    {
        return _currentCommand.ToLower() == "exit";
    }

    private void ProcessMapCommand()
    {
        _map.MovePlayer(_currentCommand);
        Vector2Int playerPosition = _map.GetPlayerPosition();
        Console.WriteLine($"You are at {playerPosition.X}, {playerPosition.Y}");
        Console.WriteLine(CurrentLocationDescription());
    }

    private void ProcessInventoryCommand()
    {
        
    }
    
    #endregion
    
    #endregion
}