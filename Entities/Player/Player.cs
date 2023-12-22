using Godot;
using System;
using System.ComponentModel;

public partial class Player : CharacterBody2D
{
	public float moveSpeed = 150.0f;
	public float jumpVelocity = 400.0f;
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _PhysicsProcess(double delta)
    {
		Vector2 velocity = this.Velocity;
		GD.Print(velocity);

		velocity = applyGravityEffect(velocity, delta);
		velocity = applyPlayerMoveInput(velocity, delta);

		this.Velocity = velocity;
		MoveAndSlide();
    }

	private Vector2 applyGravityEffect(Vector2 velocity, double delta)
	{
		if (!IsOnFloor())
		{
			velocity.Y += this.gravity * (float)delta;
		}

		return velocity;
	}

	private Vector2 applyPlayerMoveInput(Vector2 velocity, double delta)
	{	
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X = -this.moveSpeed;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			velocity.X = this.moveSpeed;
		}
		else
		{
			velocity.X = 0;
		}

		if (Input.IsActionPressed("jump") && IsOnFloor())
		{
			velocity.Y = -this.jumpVelocity;
		}

		return velocity;
	}



}
