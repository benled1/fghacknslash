using Godot;
using System;

public partial class PigDamaged : State
{
	public Pig pig;

    public override void Init()
    {
		pig = this.fsm.GetParent<Pig>();
    }
	
    public override void Enter()
    {
        pig.animationPlayer.Play("Damaged");
    }

    public override void Exit()
    {
        pig.statsComponent.knockBackForce = 0;
    }

    public override void PhysicsUpdate(float delta)
    {
        Vector2 velocity = pig.Velocity;

		velocity = _applyGravity(velocity, delta);
		velocity = _applyKnockBack(velocity);
		


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

	private Vector2 _applyKnockBack(Vector2 velocity)
	{
		if (pig.statsComponent.direction == -1)
		{
			velocity.X += pig.statsComponent.knockBackForce;
		}
		else if (pig.statsComponent.direction == 1)
		{
			velocity.X -= pig.statsComponent.knockBackForce;
		}
		return velocity;
	}

	private void _OnAnimationPlayerAnimationFinished(string anim)
	{
		if (anim == "Damaged")
		{
			fsm.TransitionTo("Follow");
		}
	}
}
