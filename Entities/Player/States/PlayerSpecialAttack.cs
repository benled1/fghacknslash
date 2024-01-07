using Godot;
using System;

public partial class PlayerSpecialAttack : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("SpecialAttack");
	}

    private void _OnAnimationPlayerAnimationFinished(string anim)
    {
        if (anim != "SpecialAttack")
        {
            return;
        }

        if (player.Velocity.Y >= 0)
        {
            if (player.Velocity.X != 0)
            {
                fsm.TransitionTo("Move");
            }
            else
            {
                fsm.TransitionTo("Idle");
            }
        }
    }

    private void _OnAttackHitboxAreaEntered(Area2D area2D)
    {
        if (area2D.GetType() == typeof(HitboxComponent))
        {
            HitboxComponent hitbox = (HitboxComponent) area2D;
            if (fsm.currentState is PlayerSpecialAttack)
            {
                BrawlerSpecialAttack attackObject = new BrawlerSpecialAttack(this.player.statsComponent);
                hitbox.hit(attackObject);
            }
        }
    }
}
