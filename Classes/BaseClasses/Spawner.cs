using Godot;
using Godot.Collections;
using System;



public partial class Spawner: Node2D
{
    public PackedScene spawnableEntity;
    public float spawnInterval;

    protected virtual void spawnEntity() {}
}