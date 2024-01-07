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
		if (statsComponent.invincible)
		{
			return;
		}

		attack.damage(statsComponent);
		if (statsComponent.healthStats.currentHealth <= 0)
		{
			stateMachine.TransitionTo("Death");
		}
		else
		{
			if (statsComponent.GetParent() is Player player)
			{
				player.iFrames.Start();
			}
			else 
			{
				stateMachine.TransitionTo("Damaged");
			}
		}
	}
}
