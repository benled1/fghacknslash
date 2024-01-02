using Godot;
using System;
using System.ComponentModel;


public partial class Player : CharacterBody2D
{
    public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
	public float moveSpeed = 150.0f;
	public float airControlSpeed = 5.0f;
	public float jumpVelocity = 500.0f;
	
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private StateMachine stateMachine;


	public override void _Ready()
	{
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