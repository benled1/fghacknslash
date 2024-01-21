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
		GD.Print("HIT SMTH");
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
			if (!statsComponent.defenseStats.staggerable)
			{
				// this should be handled in some generic status way through the status system when it is implemented
				if (statsComponent.GetParent() is Player player)
				{
					player.iFrames.Start();
				} 
				else 
				{
					GD.Print("HIT THE ENEMY");
				}
				
			}
			else 
			{
				stateMachine.TransitionTo("Damaged");
			}
		}
	}
}
