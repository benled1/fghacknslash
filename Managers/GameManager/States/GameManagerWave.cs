using Godot;
using System;

public partial class GameManagerWave : State
{
    public override void Enter()
    {
        GD.Print("Entering Wave State");
    }

    public override void HandleInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("pause"))
		{
			fsm.TransitionTo("Paused");
		}
    }
}
