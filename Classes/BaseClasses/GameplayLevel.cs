using Godot;

public class GameplayLevel 
{
    public string scenePath;
    public Vector2 playerSpawnLocation;
    public bool entryLevel;

    public GameplayLevel(string _scenePath, Vector2 _playerSpawnLocation, bool _entryLevel)
    {
        this.scenePath = _scenePath;
        this.playerSpawnLocation = _playerSpawnLocation;
        this.entryLevel = _entryLevel;
    }
}