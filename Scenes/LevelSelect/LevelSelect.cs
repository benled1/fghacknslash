using Godot;
using System;

public partial class LevelSelect : Node2D
{
	private void onWorld1ButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/World1/World1.tscn");
	}


}
