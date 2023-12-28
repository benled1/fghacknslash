using Godot;
using System;

public partial class InputManager : Node2D
{
	enum InputState
	{
		INGAME,
		PAUSED,
		MAINMENU
	}
	private GlobalSignals _globalSignals;
	private InputState _inputState;

	public override void _Ready()
	{
		_globalSignals = GetNode<GlobalSignals>("/root/GlobalSignals");
		// set inputState to INGAME since there is no mainmenu or anything
		this._inputState = InputState.INGAME;
	}
	public override void _PhysicsProcess(double delta)
	{
		switch(this._inputState)
		{
			case InputState.INGAME:
				processInputInGame();
				break;
			case InputState.MAINMENU:
				GD.Print("MAINMENU INPUT NOT IMPLEMENTED");
				break;
			case InputState.PAUSED:
				GD.Print("PAUSED INPUT NOT IMPLEMENTED");
				break;
		}
	}

	private void processInputInGame()
	{
		if (Input.IsActionPressed("move_left"))
		{
			_globalSignals.EmitSignal(GlobalSignals.SignalName.moveLeft);
		}
		if (Input.IsActionPressed("move_right"))
		{
			_globalSignals.EmitSignal(GlobalSignals.SignalName.moveRight);
		}
	}
}


