using System;
using Godot;
using Godot.Collections;


public partial class PigSpawner: Spawner
{
    public float beginningSpawnDifficulty = 400;

    private GameManager gameManager;
    private int spawnTickCount = 0;
    private Array<Vector2I> possibleSpawnLocations;
    private TileMap tileMap;
    private Random random = new Random();

    public override void _Ready()
    {
        base._Ready();
        this.gameManager = GetTree().CurrentScene.GetNode<GameManager>("GameManager");
        this.spawnableEntity = ResourceLoader.Load<PackedScene>("res://Entities/Enemies/Pig/Pig.tscn");
        this.tileMap = GetTree().CurrentScene.GetNode<TileMap>("TileMap");
        this.possibleSpawnLocations = getSpawnLocations();
    }

    public override void _Process(double delta)
    {
        _updateSpawnInterval();
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
    }

    private Array<Vector2I> getSpawnLocations()
    {
        Array<Vector2I> possibleSpawnTileLocations = this.tileMap.GetUsedCellsById(layer: 0, sourceId: 0); // this is a Godot array
        Vector2I tileSize = this.tileMap.TileSet.TileSize;

        for (int i=0;i<possibleSpawnTileLocations.Count;i++)
        {
            Vector2I tempVector = new Vector2I(possibleSpawnTileLocations[i].X * tileSize.X, possibleSpawnTileLocations[i].Y * tileSize.Y);
            possibleSpawnTileLocations[i] = tempVector;
        }
        return possibleSpawnTileLocations;
    }

    private void _updateSpawnInterval()
    {
        this.spawnInterval = this.beginningSpawnDifficulty/(float)Math.Floor(this.gameManager.difficultyManager.difficultyScale);
    }
}