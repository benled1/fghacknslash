using Godot;



public partial class SceneSwitcher: Node
{

    public string gameplayLevel;
    private PackedScene newScene;
    private LoadingScreen loadingScreen;

    public override void _Ready()
    {
        this.loadingScreen = GetNode<LoadingScreen>("/root/LoadingScreen");
    }

    public void loadGameplay(string levelPath)
    {
        this.gameplayLevel = levelPath;
        GetTree().ChangeSceneToFile("res://Scenes/Gameplay/Gameplay.tscn");
    }

}