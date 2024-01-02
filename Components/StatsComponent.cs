using Godot;
using System;

public partial class StatsComponent : Node2D
{
	public float maxHealth;
	public float currentHealth;
	public float knockBackForce;
	public int direction;
	public float gravity;
	public float moveSpeed;
	public float jumpVelocity;


	public void Init(float maxHealth, 
					int direction, 
					float moveSpeed,
					float jumpVelocity)
	{
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.direction = direction;
		this.knockBackForce = 0;
		this.gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		this.moveSpeed = moveSpeed;
		this.jumpVelocity = jumpVelocity;
	}
}
