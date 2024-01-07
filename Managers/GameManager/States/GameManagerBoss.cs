using Godot;
using System;

public partial class GameManagerBoss : State
{
    public override void Enter()
    {
        GD.Print("Entering Boss State");
    }

	public override void HandleInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("pause"))
		{
			fsm.TransitionTo("Paused");
		}
    }
}
