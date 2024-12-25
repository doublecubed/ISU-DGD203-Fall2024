namespace FirstGame;

public class Game
{
    #region REFERENCES
    
    private Player _player;
    private GameMap _map;
    private Commands _commands;
    private Inventory _inventory;
    private SaveManager _saveManager;
    
    #endregion
    
    #region VARIABLES
    
    #region Constant Variables
    
    private const int MapWidth = 5;
    private const int MapHeight = 5;

    private const string NewCommandSeparator = "--------------------------";
    
    public static readonly Vector2Int DefaultStartingCoordinates = new Vector2Int { X = 0, Y = 0 };
    
    #endregion
    
    #region Game State Variables
    
    private bool _isRunning;
    
    #endregion
    
    #region Command Variables
    
    private string _currentCommand;
    
    #endregion
    
    #endregion
    
    #region CONSTRUCTOR
    
    public Game()
    {
        GenerateMap();
        GenerateStartingInstances();
        InitializeStartingInstances();
        CheckForLoadGame();
    }

    #endregion
    
    #region METHODS
    
    #region Starting Methods
    
    public void StartGame()
    {
        GetPlayerName();

        StartGameLoop();
        GameLoop();
        
        // This will run only after the game ends
    }

    private void GenerateStartingInstances()
    {
        _player = new Player();
        _inventory = new Inventory(this);
        _saveManager = new SaveManager(this);
        _commands = new Commands(this);
    }

    private void InitializeStartingInstances()
    {
        _saveManager.Initialize(_player, _map);
        _commands.Initialize(_map, _saveManager, _player);
    }
    
    private void GenerateMap()
    {
        _map = new GameMap(this, MapWidth, MapHeight, DefaultStartingCoordinates);
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


        _player.SetUp(playerName);

        Console.WriteLine($"Welcome, {_player.Name}, to this game");
    }

    private void CheckForLoadGame()
    {
        if (_saveManager.SaveFileExists())
        {
            Console.WriteLine("Save file found. Do you want to load the game? Y/N");
            string answer = Console.ReadLine();
            if (answer != null && answer.ToLower() == "y")
            {
                _saveManager.LoadGame();
            }
        }
        
    }
    
    #endregion
    
    #region Game Loop Methods

    private void StartGameLoop()
    {
        _isRunning = true;
        // something extra
    }

    private void GameLoop()
    {
        while (_isRunning)
        {
            ReceiveCommand();
            ApplyCommand();
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
        _commands.ExecuteCommand(_currentCommand);
    }
    
    public void GiveExitCommand()
    {
        _isRunning = false;
    }
   
    #endregion
    
    #endregion
}