using Godot;
using System;

public partial class Pig : CharacterBody2D
{
    // HIDDEN STATS
    // public int direction = -1;
    // public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    // public float knockBackForce = 0.0f;

    // INGAME STATS
	// public float moveSpeed = 100.0f;
	// public float jumpVelocity = 300.0f;

    // STATS COMPONENT INITIAL VALUES
    private float maxHealth = 50;
	private int direction = -1;
	private float moveSpeed = 100;
	private float jumpVelocity = 50;

    // NODE REFERENCES
	public Player player;
	public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
    public StateMachine stateMachine;
    public StatsComponent statsComponent;
    public HitboxComponent hitboxComponent;




    public override void _Ready()
    {
        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");
        
        // INIT
        this.statsComponent.Init(maxHealth, direction, moveSpeed, jumpVelocity);
		this.stateMachine.Init();
    }

	public override void _Process(double delta)
    {
        this.stateMachine.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        this.stateMachine.PhysicsUpdate(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        this.stateMachine.HandleInput(@event);
    }


}
