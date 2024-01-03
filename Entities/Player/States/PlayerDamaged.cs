using Godot;
using System;

public partial class PlayerDamaged : State
{
	public Player player;
    public override void Init()
    {
        player = this.fsm.GetParent<Player>();
    }
    public override void Enter()
	{
        player.iFrames.Start();
		fsm.TransitionTo("Idle");
	}


}
