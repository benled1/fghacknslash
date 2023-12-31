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

	
}
