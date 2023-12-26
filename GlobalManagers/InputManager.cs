using Godot;
using System;

public partial class InputManager : Node2D
{
	private GlobalSignals _globalSignals;

	public override void _Ready()
	{
		_globalSignals = GetNode<GlobalSignals>("/root/GlobalSignals");
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("move_left"))
		{
			_globalSignals.EmitSignal(GlobalSignals.SignalName.moveLeft);
		}
	}
}
