using Godot;



public partial class Spawner: Node2D
{

    public PackedScene spawnableEntity;
    public float spawnInterval;

    protected virtual void spawnEntity() {}

}