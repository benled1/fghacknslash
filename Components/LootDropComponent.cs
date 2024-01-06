using System.Collections.Generic;
using System;
using Godot;



public partial class LootDropComponent: Node2D
{
    public Dictionary<PackedScene, int> dropTable;
    private Node2D parent;
    private Random random = new Random();

    public override void _Ready()
    {
        this.parent = GetParent<Node2D>();
    }

    public void Init(Dictionary<PackedScene, int> dropTable)
    {
        this.dropTable = dropTable;
    }

    public void dropLoot()
    {
        int lootDrop = this.random.Next(1, 100);
        foreach (KeyValuePair<PackedScene, int> kvp in this.dropTable)
        {
            if (lootDrop < kvp.Value)
            {
                Consumable droppedItem = kvp.Key.Instantiate<Consumable>();
                droppedItem.Position = this.parent.Position;
                // need to instantiate the scene and add it to the world scene.
                // to do this we need global access to the current meta scene.
                parent.GetParent().AddChild(droppedItem);
                break;
            }
        }
    }
}