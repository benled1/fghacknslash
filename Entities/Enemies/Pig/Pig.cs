using Godot;
using System;

public partial class Pig : Entity
{
    // HIDDEN STATS
    public int direction = -1;
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    public float knockBackForce = 0.0f;

    // INGAME STATS
	public float moveSpeed = 100.0f;
	public float jumpVelocity = 300.0f;

    // NODE REFERENCES
	public Player player;
	public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;


    public override void _Ready()
    {
        // BASE CLASS FIELDS
        this.hostile = true;
        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");

        // PIG FIELDS
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        

        // INIT
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
