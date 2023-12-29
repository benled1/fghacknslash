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
    }

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = player.Velocity;
		if (!player.IsOnFloor())
        {
            velocity.Y += player.gravity * delta;
        }
        velocity.X = 0;
        player.Velocity = velocity;
        player.MoveAndSlide();
	}

	public override void HandleInput(InputEvent @event)
	{
		if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
        {
            fsm.TransitionTo("Move");
        }    
	}

}
