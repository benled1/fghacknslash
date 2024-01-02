using Godot;
using System;
using System.Reflection;

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

    // TODO: implement the state transitions between basic attack and other states.

    // remember that signals can still be run even if the state is not active.
    // LOOK INTO THIS SINCE THIS CODE WAS RUNNING DURING OTHER STATES
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

    // private void _OnArea2DBodyEntered(Node2D body)
    // {
    //     GD.Print(body);
    //     if (body is HitboxComponent hitboxComponent)
    //     {
    //         BrawlerBasicAttack attackObject = new BrawlerBasicAttack();
    //         hitboxComponent.hit(attackObject);
    //     }
    // }

    private void _OnAttackHitboxAreaEntered(Area2D area2D)
    {
        if (area2D.GetType() == typeof(HitboxComponent))
        {
            HitboxComponent hitbox = (HitboxComponent) area2D;
            BrawlerBasicAttack attackObject = new BrawlerBasicAttack();
            hitbox.hit(attackObject);
        }
    }
}
