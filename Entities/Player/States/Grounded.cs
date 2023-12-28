using Godot;
using System;

public partial class Grounded : State
{

	private GlobalSignals _globalSignals;
	private Player _player;
	
	public override void Enter()
	{
		GD.Print("Entering Grounded State");
	}

	public override void Exit()
	{
		GD.Print("Exiting Grounded State");
	}

	public override void _Ready()
	{
		_globalSignals = GetNode<GlobalSignals>("/root/GlobalSignals");
		_player = GetNode<Player>("../../../Player");
		// subscribe to events
		connectSignals();
	}

	public void handleMoveLeft()
	{
	  this._player.moveLeft();
	}

	public void handleMoveRight()
	{
	  this._player.moveRight();
	}
	
	private void connectSignals()
	{
		_globalSignals.moveLeft += handleMoveLeft;
		_globalSignals.moveRight += handleMoveRight;
	}
}
