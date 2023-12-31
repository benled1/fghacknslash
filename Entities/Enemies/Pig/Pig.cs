using Godot;
using System;

public partial class Pig : Entity
{
	public float moveSpeed = 100.0f;
	public float jumpVelocity = 300.0f;

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public Player player;
	public AnimationPlayer animationPlayer;

    public Node2D spriteContainer;
	private StateMachine stateMachine;

    public override void _Ready()
    {
        this.hostile = true;
		this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");

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
