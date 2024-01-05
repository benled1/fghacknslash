using Godot;
using System;

public partial class PickUpRange : Area2D
{
	private Player player;

    public override void _Ready()
    {
        this.player = GetParent<Player>();
    }
    private void _OnBodyEntered(Node2D body)
	{
		if (body is Consumable consumable)
		{
			GD.Print("ENABLING TRACKING");
			consumable.enableTracking(this.player);
		}
	}

	private void _OnBodyExited(Node2D body)
	{
		if (body is Consumable consumable)
		{
			consumable.disableTracking();
		}
	}
}
