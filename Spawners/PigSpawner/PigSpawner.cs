using System;
using Godot;
using Godot.Collections;


public partial class PigSpawner: Spawner
{
    public float beginningSpawnDifficulty = 400;
    private GameManager gameManager;
    private int spawnTickCount = 0;
    private int initialSpawnLevel = 1;
    private int spawnLevel;
    private Array<Vector2I> possibleSpawnLocations;
    private TileMap tileMap;
    private Random random = new Random();

    public override void _Ready()
    {
        base._Ready();
        this.gameManager = GetTree().CurrentScene.GetNode<GameManager>("GameManager");
        this.tileMap = GetTree().CurrentScene.GetNode<TileMap>("TileMap");
        this.spawnableEntity = ResourceLoader.Load<PackedScene>("res://Entities/Enemies/Pig/Pig.tscn");
        this.possibleSpawnLocations = getSpawnLocations();
    }

    public override void _Process(double delta)
    {
        _scaleDifficulty();
        this.spawnTickCount += 1;
        if (this.spawnTickCount >= this.spawnInterval)
        {
            spawnEntity();
            this.spawnTickCount = 0;
        }
    }

    protected override void spawnEntity()
    {
        Pig spawnedPig = this.spawnableEntity.Instantiate<Pig>();
        spawnedPig.Position = this.possibleSpawnLocations[this.random.Next(0, possibleSpawnLocations.Count-1)];
        GetTree().CurrentScene.AddChild(spawnedPig);
        // level up to the spawnLevel
        for (int i=0;i<this.spawnLevel-1;i++)
        {

            spawnedPig.level.levelUp();
        }
    }

    private Array<Vector2I> getSpawnLocations()
    {
        Array<Vector2I> possibleSpawnTileLocations = this.tileMap.GetUsedCellsById(layer: 0, sourceId: 0);
        Vector2I tileSize = this.tileMap.TileSet.TileSize;

        for (int i=0;i<possibleSpawnTileLocations.Count;i++)
        {
            Vector2I tempVector = new Vector2I(possibleSpawnTileLocations[i].X * tileSize.X, possibleSpawnTileLocations[i].Y * tileSize.Y);
            possibleSpawnTileLocations[i] = tempVector;
        }
        return possibleSpawnTileLocations;
    }

    private void _scaleDifficulty()
    {
        this.spawnInterval = this.beginningSpawnDifficulty/(float) Math.Floor(this.gameManager.difficultyManager.difficultyScale);
        this.spawnLevel = this.initialSpawnLevel + (int) Math.Floor(this.gameManager.difficultyManager.difficultyScale)-1;
    }
}