using Godot;
using System;

public partial class HitboxComponent : Area2D
{
	public StatsComponent statsComponent;
	public StateMachine stateMachine;

    public override void _Ready()
    {
		stateMachine = GetNode<StateMachine>("../StateMachine");
        statsComponent = GetNode<StatsComponent>("../StatsComponent");
    }

    public void hit(Attack attack)
	{
		attack.damage(statsComponent);
		stateMachine.TransitionTo("Damaged");
	}
}
