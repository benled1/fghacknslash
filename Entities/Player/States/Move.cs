using Godot;
using System;

public partial class Move : State
{

    public Player player;

    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animatedSprite2D.Play("Walk");
	}

	public override void Exit()
	{
	}

    public override void Update(float delta)
    {
    }

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = player.Velocity;
		
		if (Input.IsActionPressed("move_left"))
		{
			velocity = _moveLeft(velocity);
		}
		else if (Input.IsActionPressed("move_right"))
		{
			velocity = _moveRight(velocity);
		}
		else
		{
			fsm.TransitionTo("Idle");
		}


		_applyGravity(velocity, delta);

        player.Velocity = velocity;
        player.MoveAndSlide();
	}

	public override void HandleInput(InputEvent @event)
	{
	}

	private Vector2 _moveRight(Vector2 velocity)
	{
		velocity.X = player.moveSpeed;
		player.animatedSprite2D.FlipH = false;
		return velocity;
	}


	private Vector2 _moveLeft(Vector2 velocity)
	{
		velocity.X = -player.moveSpeed;
		player.animatedSprite2D.FlipH = true;
		return velocity;
	}

	private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!player.IsOnFloor())
        {
            velocity.Y += player.gravity * delta;
        }
		return velocity;
	}
}
