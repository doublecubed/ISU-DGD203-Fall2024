namespace FirstGame;

public class SaveManager
{
    #region REFERENCES
    
    private Game _game;
    private Player _player;
    private GameMap _gameMap;
    
    #endregion
    
    #region INITIALIZATION
    
    public SaveManager(Game game)
    {
        _game = game;
    }

    public void Initialize(Player player, GameMap gameMap)
    {
        _player = player;
        _gameMap = gameMap;
    }
    
    #endregion
    
    #region METHODS
    
    public void SaveGame()
    {
        string savePath = SavePath();
        
        string playerName = _player.Name;
        
        Vector2Int playerPosition = _gameMap.GetPlayerPosition();
        string playerPositionString = $"{playerPosition.X.ToString()},{playerPosition.Y.ToString()}";
        
        string saveContent = $"{playerName}{Environment.NewLine}{playerPositionString}";

        File.WriteAllText(savePath, saveContent);

    }

    public bool SaveFileExists()
    {
        return File.Exists(SavePath());
    }
    
    public void LoadGame()
    {
        string savePath = SavePath();
        
        string[] saveContent = File.ReadAllLines(savePath);
        for (int i = 0; i < saveContent.Length; i++)
        {
            string contentLine = saveContent[i];
            
            if (i == 0) _player.SetUp(contentLine);
            if (i == 1) _gameMap.MovePlayer(ParseToVector2Int(contentLine));
        }
    }
    
    public string SavePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string fullPath = projectDirectory + @"\save.sgf";

        return fullPath;
    }
    
    public Vector2Int ParseToVector2Int(string input)
    {
        string[] parts = input.Split(',');
        return new Vector2Int
        {
            X = int.Parse(parts[0]),
            Y = int.Parse(parts[1])
        };
    }
    
    #endregion
}