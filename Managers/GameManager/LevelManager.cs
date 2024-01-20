using Godot;
using System;
using System.Collections.Generic;

public partial class LevelManager: Node2D
{
    public Node2D currentLevel;
    public GameplayLevel currentLevelInfo;
    private Gameplay gameplayNode;
    private LoadingScreen loadingScreen;
    private Player player;
    private Dictionary<string, GameplayLevel> levelInfoDict = new Dictionary<string, GameplayLevel>();
    

    public override void _Ready()
    {
        gameplayNode = GetNode<Gameplay>("/root/Gameplay");
        loadingScreen = GetNode<LoadingScreen>("/root/LoadingScreen");
        initLevelDict();
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
        this.currentLevelInfo = this.levelInfoDict.GetValueOrDefault(levelPath);

        if (!this.currentLevelInfo.entryLevel)
        {
            this.player = GetNode<Player>("/root/Gameplay/Player");
            this.player.Position = this.currentLevelInfo.playerSpawnLocation;
        } else {
            // this happens in the Ready() function of the Player.cs
            // this is because we can't get a reference due to loading times
        }

        gameplayNode.AddChild(newLevel);
        loadingScreen.endTransition();
    }

    private void initLevelDict()
    {
        GameplayLevel testLevel = new GameplayLevel("res://Scenes/Levels/TestLevel/TestWorldWave.tscn", new Vector2(380,250), true);
        GameplayLevel testLevelBossRoom1 = new GameplayLevel("res://Scenes/Levels/TestLevel/BossLevels/Boss1Room.tscn", new Vector2(380,250), false);
        this.levelInfoDict.Add("res://Scenes/Levels/TestLevel/TestWorldWave.tscn", testLevel);
        this.levelInfoDict.Add("res://Scenes/Levels/TestLevel/BossLevels/Boss1Room.tscn", testLevelBossRoom1);
    }

}
