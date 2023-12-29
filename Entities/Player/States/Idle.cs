using Godot;
using System;

public partial class Idle : State
{
    public Player player;

    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animatedSprite2D.Play("Idle");
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
        velocity.X = 0;

        velocity = _applyGravity(velocity, delta);

        player.Velocity = velocity;
        player.MoveAndSlide();
	}

	public override void HandleInput(InputEvent @event)
	{
		if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
        {
            if (player.IsOnFloor())
            {
                fsm.TransitionTo("Move");
            }   
        }
        else if (Input.IsActionPressed("jump") && player.IsOnFloor())
        {
            fsm.TransitionTo("Jump");
        }
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

}
