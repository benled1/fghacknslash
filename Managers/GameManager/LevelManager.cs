using Godot;
using System;

public partial class LevelManager: Node2D
{
    public Node2D currentLevel;
    Node2D gameplayNode;

    public override void _Ready()
    {
        gameplayNode = GetNode<Node2D>("/root/Gameplay");
    }

    public void loadLevel(string levelPath)
    {
        if (this.currentLevel != null)
        {
            this.currentLevel.QueueFree();
        }
        PackedScene levelScene = ResourceLoader.Load<PackedScene>(levelPath);
        Node2D newLevel = levelScene.Instantiate<Node2D>();
        gameplayNode.AddChild(newLevel);
        this.currentLevel = GetNode<Node2D>($"/root/Gameplay/{this.currentLevel.Name}");

    }

}
