using Godot;
using System;

public partial class Pig : Enemy
{

    // STATS COMPONENT INITIAL VALUES
    private float maxHealth = 50;
	private int direction = -1;
	private float moveSpeed = 100;
	private float jumpVelocity = 50;
    private float attackRange = 50;


    public override void _Ready()
    {
        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");
        
        // INIT
        this.statsComponent.Init(maxHealth: maxHealth, 
                                direction: direction,
                                moveSpeed: moveSpeed,
                                jumpVelocity: jumpVelocity,
                                attackRange: attackRange);
		this.stateMachine.Init();
    }

}
