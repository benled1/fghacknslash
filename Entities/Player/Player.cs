using Godot;

public partial class Player : CharacterBody2D
{

    // STATS COMPONENT INITIAL VALUES
    private float maxHealth = 100;
	private float moveSpeed = 150;
	private float jumpVelocity = 400;
    
    // NODE REFERENCES
    public StateMachine stateMachine;
    public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
    public StatsComponent statsComponent;

	public override void _Ready()
	{
		this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");

        this.statsComponent.Init(maxHealth: maxHealth, 
                                moveSpeed: moveSpeed, 
                                jumpVelocity: jumpVelocity);
		this.stateMachine.Init();
	}

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