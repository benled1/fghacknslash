using Godot;
using System;
using System.ComponentModel;


public partial class Player : CharacterBody2D
{
	public AnimatedSprite2D animatedSprite2D;
	public float moveSpeed = 150.0f;
	public float airControlSpeed = 5.0f;
	public float jumpVelocity = 400.0f;
	
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	private MovementFSM movementFSM;


	public override void _Ready()
	{
		this.movementFSM = GetNode<MovementFSM>("MovementFSM");
		this.animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		this.movementFSM.Init();
	}

    public override void _Process(double delta)
    {
        this.movementFSM.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        this.movementFSM.PhysicsUpdate(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        this.movementFSM.HandleInput(@event);
    }

}