using Godot;
using System;

public partial class FPSCounter : ColorRect
{

	private Label fpsCounter;

    public override void _Ready()
    {
        fpsCounter = GetNode<Label>("FPS_COUNTER");
    }
    public override void _Process(double delta)
	{
		fpsCounter.Text = Engine.GetFramesPerSecond().ToString();
	}
}
