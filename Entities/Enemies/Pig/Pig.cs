using Godot;
using System;
using System.Collections.Generic;

public partial class Pig : Enemy
{

    public override void _Ready()
    {
        // define initial stats
        this.maxHealth = 50;
        this.direction = -1;
        this.moveSpeed = 100;
        this.jumpVelocity = 50;
        this.physicalAttack = 10;

        // set node references
        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");
        this.lootDropComponent = GetNode<LootDropComponent>("LootDropComponent");

        // define the drop table and init it
        _defineDropTable();
        this.lootDropComponent.Init(this.dropTable);

        // init the statsComponent with the initial stats
        this.statsComponent.Init(maxHealth: maxHealth,
                                direction: direction,
                                moveSpeed: moveSpeed,
                                jumpVelocity: jumpVelocity,
                                physicalAttack: physicalAttack);
        
        // init the statemachine
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
