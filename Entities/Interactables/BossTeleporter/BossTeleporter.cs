using Godot;
using System;

public partial class BossTeleporter : Interactable
{
	private AnimationPlayer animationPlayer;
	private Sprite2D sprite2D;
	private SceneSwitcher sceneSwitcher;

    public override void _Ready()
    {
        this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		this.sprite2D = GetNode<Sprite2D>("Sprite2D");
		this.sceneSwitcher = GetNode<SceneSwitcher>("/root/SceneSwitcher");
    }
    public override void detected()
	{
		this.sprite2D.Modulate = new Color(0.678f, 0.847f, 0.9019f);
	}

	public override void undoDetected()
	{
		this.sprite2D.Modulate = new Color(1.0f, 1.0f, 1.0f);
	}

	public override void triggerEffect()
    {
		this.undoDetected();
		this.sceneSwitcher.loadNewScene("res://Scenes/Levels/TestLevel/BossLevels/Boss1.tscn");
    }




}
