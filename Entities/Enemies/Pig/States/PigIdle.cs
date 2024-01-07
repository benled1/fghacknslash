using Godot;
using System;

public partial class PigIdle : State
{
	public Pig pig;

    public override void Init()
    {
        pig = this.fsm.GetParent<Pig>();
    }

	public override void Enter()
	{
        pig.animationPlayer.Play("Idle");
	}

	public override void Exit()
	{
	}

	public override void Update(float delta)
    {
    }

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = pig.Velocity;
        velocity.X = 0;

        velocity = _applyGravity(velocity, delta);

        pig.Velocity = velocity;
        pig.MoveAndSlide();
	}

	private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!pig.IsOnFloor())
        {
            velocity.Y += pig.statsComponent.movementStats.gravity * delta;
        }
		return velocity;
	}

	private void _OnAggroAreaBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			this.pig.player = player;
			this.fsm.TransitionTo("Follow");
		}
	}



}
