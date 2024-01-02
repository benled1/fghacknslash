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

    public override void PhysicsUpdate(float delta)
    {
        Vector2 velocity = pig.Velocity;

		velocity = _applyGravity(velocity, delta);
		


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

	private Vector2 _applyKnockBack(Vector2 velocity)
	{
		if (pig.direction == -1)
		{
			velocity.X += pig.knockBackForce;
		}
		else if (pig.direction == 1)
		{
			velocity.X -= pig.knockBackForce;
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
