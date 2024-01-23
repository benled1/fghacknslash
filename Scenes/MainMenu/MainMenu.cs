using Godot;
using System;

public partial class MainMenu : Node2D
{
	SceneSwitcher sceneSwitcher;

    public override void _Ready()
    {
        sceneSwitcher = GetNode<SceneSwitcher>("/root/SceneSwitcher");
	}
    private void onPlayButtonPressed()
	{
		this.sceneSwitcher.loadGameplay("res://Scenes/Levels/TestLevel/MobLevels/TestWorldWave/TestWorldWave.tscn");
	}
}
