using Godot;
using System;
using System.ComponentModel;


public partial class Player : CharacterBody2D
{
	public AnimatedSprite2D animatedSprite2D;
	public float moveSpeed = 150.0f;
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



    // 	
    // 	private AnimatedSprite2D animatedSprite;

    // 	public override void _Ready()
    // 	{
    // 		// init nodes
    // 		this.animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

    // 		animatedSprite.Play("Idle");
    // 	}
    // 	public override void _PhysicsProcess(double delta)
    // 	{
    // 		Vector2 velocity = this.Velocity;

    // 		velocity = applyGravityEffect(velocity, delta);
    // 		velocity = applyPlayerMoveInput(velocity, delta);

    // 		this.Velocity = velocity;
    // 		MoveAndSlide();
    // 	}

    // 	private Vector2 applyGravityEffect(Vector2 velocity, double delta)
    // 	{
    // 		if (!IsOnFloor())
    // 		{
    // 			velocity.Y += this.gravity * (float)delta;
    // 			if (velocity.Y > 0)
    // 			{
    // 				this.animatedSprite.Play("Falling");
    // 			}
    // 		}

    // 		return velocity;
    // 	}

    // 	private Vector2 applyPlayerMoveInput(Vector2 velocity, double delta)
    // 	{	
    // 		if (Input.IsActionPressed("move_left"))
    // 		{

    // 		}
    // 		else if (Input.IsActionPressed("move_right"))
    // 		{

    // 		}
    // 		else
    // 		{
    // 			// 
    // 			velocity.X = 0;
    // 			animatedSprite.Play("Idle");
    // 		}

    // 		if (Input.IsActionPressed("jump") && IsOnFloor())
    // 		{
    // 			velocity.Y = -this.jumpVelocity;
    // 			animatedSprite.Play("Jump");
    // 		}

    // 		return velocity;
    // 	}

    // 	public void moveLeft()
    // 	{
    // 		Vector2 velocity = this.Velocity;
    // 		velocity.X = -this.moveSpeed;
    // 		animatedSprite.FlipH = true;

    // 		if (IsOnFloor())
    // 		{
    // 			animatedSprite.Play("Walk");
    // 		}
    // 		this.Velocity = velocity;
    // 	}

    // 	public void moveRight()
    // 	{
    // 		Vector2 velocity = this.Velocity;
    // 		velocity.X = this.moveSpeed;
    // 		animatedSprite.FlipH = false;

    // 		if (IsOnFloor())
    // 		{
    // 			animatedSprite.Play("Walk");
    // 		}
    // 		this.Velocity = velocity;
    // 	}


}
