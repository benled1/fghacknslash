using Godot;
using System;

public partial class Fall : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animatedSprite2D.Play("Falling");
	}

	public override void Exit()
	{
	}

    public override void Update(float delta)
    {
		_flipSprite();
    }

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = player.Velocity;
		velocity = _applyGravity(velocity, delta);
		velocity = _applyAirControl(velocity);

		if (player.IsOnFloor())
		{
			if (velocity.X == 0)
			{
				fsm.TransitionTo("Idle");
			}
			else
			{
				fsm.TransitionTo("Move");
			}
		}

        player.Velocity = velocity;
        player.MoveAndSlide();
	}

	public override void HandleInput(InputEvent @event)
	{
	}

	private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!player.IsOnFloor())
        {
            velocity.Y += player.gravity * delta;
        }
		return velocity;
	}

	private void _flipSprite()
	{
		if (Input.IsActionPressed("move_left"))
		{
			player.animatedSprite2D.FlipH = true;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			player.animatedSprite2D.FlipH = false;
		}
	}

	private Vector2 _applyAirControl(Vector2 velocity)
	{
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= player.airControlSpeed;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			velocity.X += player.airControlSpeed;
		}
		return velocity;
	}
}
