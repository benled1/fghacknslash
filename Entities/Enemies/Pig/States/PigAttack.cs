using Godot;
using System;

public partial class PigAttack : State
{
	public Pig pig;

	public override void Init()
    {
		pig = this.fsm.GetParent<Pig>();
    }
	
    public override void Enter()
    {

		Vector2 velocity = pig.Velocity;
		velocity.X = 0;
		pig.Velocity = velocity;
        pig.animationPlayer.Play("Attack");
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
            velocity.Y += pig.statsComponent.movementStats.gravity * delta;
        }
		return velocity;
	}

	private void _OnAttackHitboxAreaEntered(Area2D area2D)
	{
		if (area2D.GetType() == typeof(HitboxComponent))
		{
			HitboxComponent hitbox = (HitboxComponent) area2D;
			PigBasicAttack attackObject = new PigBasicAttack(pig.statsComponent);
			hitbox.hit(attackObject);
		}
	}

	private void _OnAnimationPlayerAnimationFinished(string anim)
	{
		if (anim == "Attack")
		{
			fsm.TransitionTo("Follow");
		}
	}
}
