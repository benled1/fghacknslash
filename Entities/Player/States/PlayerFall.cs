using Godot;
using System;

public partial class PlayerFall : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("Fall");
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
            velocity.Y += player.statsComponent.movementStats.gravity * delta;
        }
		return velocity;
	}

	private void _flipSprite()
	{
		if (Input.IsActionPressed("move_left"))
		{
			player.spriteContainer.Scale = new Vector2(-1, player.spriteContainer.Scale.Y);
		}
		else if (Input.IsActionPressed("move_right"))
		{
			player.spriteContainer.Scale = new Vector2(1, player.spriteContainer.Scale.Y);
		}
	}

	private Vector2 _applyAirControl(Vector2 velocity)
	{
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= player.statsComponent.movementStats.airControlSpeed;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			velocity.X += player.statsComponent.movementStats.airControlSpeed;
		}
		return velocity;
	}
}
