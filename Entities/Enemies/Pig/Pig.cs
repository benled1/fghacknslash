using Godot;
using System;
using System.Collections.Generic;

public partial class Pig : Enemy
{

    public override void _Ready()
    {
        this.maxHealth = 50;
        this.direction = -1;
        this.moveSpeed = 100;
        this.jumpVelocity = 50;
        this.attackRange = 50;

        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");
        this.lootDropComponent = GetNode<LootDropComponent>("LootDropComponent");

        _defineDropTable();
        this.lootDropComponent.Init(this.dropTable);
        this.statsComponent.Init(maxHealth: maxHealth,
                                direction: direction,
                                moveSpeed: moveSpeed,
                                jumpVelocity: jumpVelocity,
                                attackRange: attackRange);
		this.stateMachine.Init();
    }

    private void _defineDropTable()
    {
        this.dropTable = new Dictionary<PackedScene, int>()
        {
            {ResourceLoader.Load<PackedScene>("res://Consumables/XpBall/XpBall.tscn"), 100}
        };
    }

}
