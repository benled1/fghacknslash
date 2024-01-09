using Godot;
using System;

public partial class MainMenu : Node2D
{
	private void onPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/World1/TestWorldWave.tscn");	
	}
}
