using Godot;



public partial class Boss: CharacterBody2D
{
    protected float maxHealth;
	protected int direction;
	protected float moveSpeed;
	protected float jumpVelocity;
    protected float physicalAttack;
    protected int bossPhase;
    protected bool staggerable;

    public StateMachine stateMachine;
    public AnimationPlayer animationPlayer;
    public StatsComponent statsComponent;

}