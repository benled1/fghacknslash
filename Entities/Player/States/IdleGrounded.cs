using Godot;
using System;

public partial class IdleGrounded : State
{

    private GlobalSignals _globalSignals;
    public override void Enter()
    {
        GD.Print("Entering IdleGrounded State");
    }

    public override void Exit()
    {
		GD.Print("Exiting IdleGrounded State");
    }

    public override void _Ready()
    {
      _globalSignals = GetNode<GlobalSignals>("/root/GlobalSignals");
      _globalSignals.moveLeft += handleMoveLeft;
    }

    public void handleMoveLeft()
    {
      GD.Print("Handling move left");
    }
}
