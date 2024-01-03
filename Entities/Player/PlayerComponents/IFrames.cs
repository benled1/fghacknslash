using Godot;
using System;

public partial class IFrames : Timer
{
	public Player player;
    public override void _Ready()
	{
		player = GetParent<Player>();
	}
    public override void _Process(double delta)
	{
		if (!this.IsStopped())
		{
			player.sprite.Modulate = new Color(1.0f, 0.0f, 0.0f);
			player.statsComponent.invincible = true;
		}
		else
		{
			player.sprite.Modulate = new Color(1.0f, 1.0f, 1.0f);
			player.statsComponent.invincible = false;
		}
	}
}
