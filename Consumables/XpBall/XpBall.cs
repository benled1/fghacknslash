using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class XpBall : Consumable
{
	public float xpValue = 1;

    protected override void triggerEffect()
    {
        GD.Print("XP increased by: " + xpValue);
		this.QueueFree();
    }

	private void _OnPickUpCollisionBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			triggerEffect();
		}
	}

}
