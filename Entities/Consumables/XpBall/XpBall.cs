using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class XpBall : Consumable
{
	public float xpValue = 10;
    protected override void triggerEffect(Player player)
    {
		player.level.gainXP(this.xpValue);
		this.QueueFree();
    }

	private void _OnPickUpCollisionBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			triggerEffect(player);
		}
	}

}
