using Godot;
using System;

public partial class LoadingScreen : CanvasLayer
{
	private AnimationPlayer animationPlayer;
	private string currentTransition;

    public override void _Ready()
    {
        this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }
    public void startTransition(string transitionType)
	{

		if (transitionType == "fade")
		{
			this.animationPlayer.Play("FadeOut");
			this.currentTransition = "fade";
		}
	}

	public void endTransition()
	{
		if (this.currentTransition == "fade")
		{
			this.animationPlayer.Play("FadeIn");
		}
	}
}
