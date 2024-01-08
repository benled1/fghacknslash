using System;
using Godot;


public partial class PigSpawner: Spawner
{
    public float beginningSpawnDifficulty = 400;
    
    private GameManager gameManager;
    private Random random = new Random();
    private int spawnTickCount = 0;

    public override void _Ready()
    {
        this.gameManager = GetTree().CurrentScene.GetNode<GameManager>("GameManager");
        this.spawnableEntity = ResourceLoader.Load<PackedScene>("res://Entities/Enemies/Pig/Pig.tscn");
    }
    protected override void spawnEntity()
    {
        Pig spawnedPig = this.spawnableEntity.Instantiate<Pig>();
        spawnedPig.Position = this.Position;
        GetTree().CurrentScene.AddChild(spawnedPig);

    }

    public override void _Process(double delta)
    {
        _updateSpawnInterval();
        GD.Print(this.gameManager.difficultyManager.difficultyScale);
        this.spawnTickCount += 1;
        if (this.spawnTickCount >= this.spawnInterval)
        {
            spawnEntity();
            this.spawnTickCount = 0;
        }
    }

    private void _updateSpawnInterval()
    {
        this.spawnInterval = this.beginningSpawnDifficulty/(float)Math.Floor(this.gameManager.difficultyManager.difficultyScale);
    }
}