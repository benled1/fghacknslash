using Godot;
using System;

public partial class MainMenu : Node2D
{
	private void onPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/LevelSelect/LevelSelect.tscn");	
	}
}
