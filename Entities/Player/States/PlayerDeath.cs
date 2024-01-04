using Godot;
using System;

public partial class PlayerDeath : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.animationPlayer.Play("Death");
	}

	private void _OnAnimationPlayerAnimationFinished(string anim)
	{
		if (anim == "Death")
		{
			GD.Print("Gameover");
		}
	}
}
