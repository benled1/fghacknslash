using Godot;
using System;

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

        if (player.Velocity.Y > 0)
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


}
