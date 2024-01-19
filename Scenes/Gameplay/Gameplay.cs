using Godot;
using System;

public partial class Gameplay : Node2D
{
	private SceneSwitcher sceneSwitcher;
	public override void _Ready()
	{
		this.sceneSwitcher = GetNode<SceneSwitcher>("/root/SceneSwitcher");
		GameManager gameManagerScene = ResourceLoader.Load<PackedScene>("res://Managers/GameManager/GameManager.tscn").Instantiate<GameManager>();
		GetTree().CurrentScene.AddChild(gameManagerScene);
		gameManagerScene.levelManager.loadLevel(this.sceneSwitcher.gameplayLevel);
		Player player = ResourceLoader.Load<PackedScene>("res://Entities/Player/Player.tscn").Instantiate<Player>();
		GetTree().CurrentScene.AddChild(player);
	}
}
