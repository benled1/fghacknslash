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
        pig.animationPlayer.Play("Walk");
    }

    public override void Update(float delta)
    {
        _updateSpriteDirection();
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
            velocity.Y += pig.statsComponent.gravity * delta;
        }
		return velocity;
	}

    private Vector2 _moveRight(Vector2 velocity)
    {
        velocity.X = pig.statsComponent.moveSpeed;
        pig.statsComponent.direction = 1;
        return velocity;
    }

    private Vector2 _moveLeft(Vector2 velocity)
    {
        velocity.X = -pig.statsComponent.moveSpeed;
        pig.statsComponent.direction = -1;
        return velocity;
    }

    private void _updateSpriteDirection()
    {
        if (pig.statsComponent.direction == -1)
        {
            pig.spriteContainer.Scale = new Vector2(0.5f, pig.spriteContainer.Scale.Y);
        }
        else if (pig.statsComponent.direction == 1)
        {
            pig.spriteContainer.Scale = new Vector2(-0.5f, pig.spriteContainer.Scale.Y);
        }
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
