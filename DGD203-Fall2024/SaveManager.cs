namespace FirstGame;

public class SaveManager
{
    #region REFERENCES
    
    private Game _game;
    
    #endregion
    
    #region CONSTRUCTOR
    
    public SaveManager(Game game)
    {
        _game = game;
    }
    
    #endregion
    
    #region METHODS
    
    public void SaveGame()
    {
        string savePath = SavePath();
        string saveContent = "I'm saving this game!";

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
        foreach (string line in saveContent)
        {
            Console.WriteLine(line);
        }
    }
    
    public string SavePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string fullPath = projectDirectory + @"\save.sgf";

        return fullPath;
    }
    
    #endregion
}