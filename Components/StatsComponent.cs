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
	public float airControlSpeed;
	public float attackRange;


	public void Init(float maxHealth=0, 
					int direction=0, 
					float moveSpeed=0,
					float jumpVelocity=0,
					float airControlSpeed=0,
					float attackRange=0)
	{
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.direction = direction;
		this.knockBackForce = 0;
		this.gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		this.moveSpeed = moveSpeed;
		this.jumpVelocity = jumpVelocity;
		this.airControlSpeed = airControlSpeed;
		this.attackRange = attackRange;
	}
}
