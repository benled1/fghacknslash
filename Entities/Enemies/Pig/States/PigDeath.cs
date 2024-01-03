using Godot;
using System;

public partial class PigDeath : State
{
	public Pig pig;

    public override void Init()
    {
		pig = this.fsm.GetParent<Pig>();
    }
	
    public override void Enter()
    {
        pig.animationPlayer.Play("Death");
    }

	private void _OnAnimationPlayerAnimationFinished(string anim)
	{
		if (anim == "Death")
		{
			pig.QueueFree();
		}
	}
}
