using Godot;
using System;
using System.ComponentModel;


public partial class Player : CharacterBody2D
{
	public AnimatedSprite2D animatedSprite2D;
	public float moveSpeed = 150.0f;
	public float airControlSpeed = 5.0f;
	public float jumpVelocity = 500.0f;
	
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private StateMachine stateMachine;


	public override void _Ready()
	{
		this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

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