using Godot;
using System;

public partial class PlayerIdle : State
{
    public Player player;

    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("Idle");
	}

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = player.Velocity;
        velocity.X = 0;

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
        else if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
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

}
