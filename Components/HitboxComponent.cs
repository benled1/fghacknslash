using Godot;
using System;

public partial class HitboxComponent : Area2D
{
	public HealthComponent healthComponent;
	public Entity parentEntity;

    public override void _Ready()
    {
		parentEntity = GetParent<Entity>();
        healthComponent = GetNode<HealthComponent>("../HealthComponent");
    }

    public void hit(Attack attack)
	{
		if (healthComponent != null)
		{
			healthComponent.damage(attack);
		}
		parentEntity.stateMachine.TransitionTo("Damaged");
	}
}
