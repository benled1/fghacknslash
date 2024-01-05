using Godot;

public partial class PlayerBasicAttack : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("BasicAttack");
	}

    private void _OnAnimationPlayerAnimationFinished(string anim)
    {
        if (anim != "BasicAttack")
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
            if (fsm.currentState is PlayerBasicAttack)
            {
                BrawlerBasicAttack attackObject = new BrawlerBasicAttack();
                hitbox.hit(attackObject);
            }
        }
    }
}
