using Godot;



public partial class SceneSwitcher: Node
{
    private PackedScene newScene;
    private LoadingScreen loadingScreen;

    public override void _Ready()
    {
        this.loadingScreen = GetNode<LoadingScreen>("/root/LoadingScreen");
    }
    public void loadNewScene(string newSceneString)
    {
        this.newScene = ResourceLoader.Load<PackedScene>(newSceneString);
        this.loadingScreen.startTransition("fade");
    }

    private void _transferContent()
    {
        
    }
}