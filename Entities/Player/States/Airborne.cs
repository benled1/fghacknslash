using Godot;
using System;

public partial class Airborne : State
{
	public override void Enter()
	{
		GD.Print("Entering Airborne State");
	}

	public override void Exit()
	{
		GD.Print("Exiting Airborne State");
	}
}
