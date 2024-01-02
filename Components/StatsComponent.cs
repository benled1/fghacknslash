using Godot;
using System;

public partial class StatsComponent : Node2D
{
	public float maxHealth;
	public float currentHealth;

	public void Init(float maxHealth)
	{
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
	}
}
