using System.Collections.Generic;
using Godot;


public partial class Enemy: CharacterBody2D
{

    protected float maxHealth;
	protected int direction;
	protected float moveSpeed;
	protected float jumpVelocity;
    protected float physicalAttack;

	public Player player;
	public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
    public StateMachine stateMachine;
    public StatsComponent statsComponent;
    public HitboxComponent hitboxComponent;
    public LootDropComponent lootDropComponent;
    public Dictionary<PackedScene, int> dropTable;
    public Level level;



    public override void _Process(double delta)
    {
        this.stateMachine.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        this.stateMachine.PhysicsUpdate(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        this.stateMachine.HandleInput(@event);
    }
}