using Godot;
using System;

public partial class PlayerMove : State
{

    public Player player;

    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("Walk");
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
		
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X = -player.statsComponent.moveSpeed;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			velocity.X = player.statsComponent.moveSpeed;
		}
		else
		{
			fsm.TransitionTo("Idle");
		}

		velocity = _applyGravity(velocity, delta);

		if (velocity.Y > 0)
		{
			fsm.TransitionTo("Fall");
		}

        player.Velocity = velocity;
        player.MoveAndSlide();
	}

	public override void HandleInput(InputEvent @event)
	{
		if (Input.IsActionJustPressed("basic_attack"))
		{
			fsm.TransitionTo("BasicAttack");
		}
		else if (Input.IsActionJustPressed("special_attack"))
		{
			fsm.TransitionTo("SpecialAttack");
		}
		else if (Input.IsActionJustPressed("jump") && player.IsOnFloor())
        {
            fsm.TransitionTo("Jump");
        }
	}


	private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!player.IsOnFloor())
        {
            velocity.Y += player.statsComponent.gravity * delta;
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
}
