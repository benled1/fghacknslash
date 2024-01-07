using Godot;
using System;

public partial class StatsComponent : Node2D
{

	public DamageStats damageStats = new DamageStats();
	public HealthStats healthStats = new HealthStats();
	public MovementStats movementStats = new MovementStats();

	//move invincible to a statuses system.
	public bool invincible;


	public void Init(float maxHealth=0, 
					int direction=0, 
					float moveSpeed=0,
					float jumpVelocity=0,
					float airControlSpeed=0,
					float attackRange=0)
	{
		this.healthStats.maxHealth = maxHealth;
		this.healthStats.currentHealth = maxHealth;
		this.movementStats.direction = direction;
		this.damageStats.knockBackForce = 0;
		this.movementStats.gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		this.movementStats.moveSpeed = moveSpeed;
		this.movementStats.jumpVelocity = jumpVelocity;
		this.movementStats.airControlSpeed = airControlSpeed;
		this.damageStats.attackRange = attackRange;
		this.invincible = false;
	}
}
