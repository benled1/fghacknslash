using Godot;
using System;


public partial class PigFollow : State
{
    public Pig pig;

    private Timer aggroTimer;

    public override void Init()
    {
        pig = this.fsm.GetParent<Pig>();
        aggroTimer = GetNode<Timer>("../../AggroTimer");
    }

    public override void Enter()
    {
        pig.animatedSprite2D.Play("Walk");
    }

    public override void PhysicsUpdate(float delta)
    {

        Vector2 velocity = pig.Velocity;
        velocity = _applyGravity(velocity, delta);

        if (pig.player.Position.X > pig.Position.X)
        {
            velocity = _moveRight(velocity);
        }
        else if (pig.player.Position.X < pig.Position.X)
        {
            velocity = _moveLeft(velocity);
        }

        pig.Velocity = velocity;
        pig.MoveAndSlide();
    }

    private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!pig.IsOnFloor())
        {
            velocity.Y += pig.gravity * delta;
        }
		return velocity;
	}

    private Vector2 _moveRight(Vector2 velocity)
    {
        velocity.X = pig.moveSpeed;
        pig.animatedSprite2D.FlipH = true;
        return velocity;
    }

    private Vector2 _moveLeft(Vector2 velocity)
    {
        velocity.X = -pig.moveSpeed;
        pig.animatedSprite2D.FlipH = false;
        return velocity;
    }

    private void _OnAggroTimerTimeout()
    {
        fsm.TransitionTo("Idle");
    }

    private void _OnArea2DBodyExited(Node2D body)
    {
        if (body is Player player)
        {
            aggroTimer.Start();
        }
    }

    private void _OnArea2DBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
            if (!aggroTimer.IsStopped())
            {
                aggroTimer.Stop();
            }
		}
	}
}
