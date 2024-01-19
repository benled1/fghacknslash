using Godot;
using System;

public partial class LevelManager: Node2D
{
    public Node2D currentLevel;
    private Gameplay gameplayNode;
    private LoadingScreen loadingScreen;

    public override void _Ready()
    {
        gameplayNode = GetNode<Gameplay>("/root/Gameplay");
        loadingScreen = GetNode<LoadingScreen>("/root/LoadingScreen");
    }

    public void loadLevel(string levelPath)
    {
        loadingScreen.startTransition("fade");
        if (this.currentLevel != null)
        {
            this.currentLevel.QueueFree();
            foreach (Node2D node in GetTree().CurrentScene.GetChildren())
            {
                if (node is Enemy enemy)
                {
                    enemy.QueueFree();
                }
            }
        }
        PackedScene levelScene = ResourceLoader.Load<PackedScene>(levelPath);
        Node2D newLevel = levelScene.Instantiate<Node2D>();
        this.currentLevel = newLevel;
        gameplayNode.AddChild(newLevel);
        loadingScreen.endTransition();
    }

}
