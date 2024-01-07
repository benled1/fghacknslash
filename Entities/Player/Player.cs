using Godot;

public partial class Player : CharacterBody2D
{

    // STATS COMPONENT INITIAL VALUES
    private float maxHealth = 100;
	private float moveSpeed = 150;
	private float jumpVelocity = 600;
    private float physicalAttack = 10;
    private float knockBackForce = 10;

    
    // NODE REFERENCES
    public StateMachine stateMachine;
    public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
    public Sprite2D sprite;
    public StatsComponent statsComponent;
    public Timer iFrames;
    public PlayerLevel level;

	public override void _Ready()
	{
		this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.spriteContainer = GetNode<Node2D>("SpriteContainer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");
        this.sprite = GetNode<Sprite2D>("SpriteContainer/Sprite2D");
        this.iFrames = GetNode<Timer>("IFrames");
        this.level = new PlayerLevel(this);

        this.statsComponent.Init(maxHealth: maxHealth, 
                                moveSpeed: moveSpeed, 
                                jumpVelocity: jumpVelocity,
                                physicalAttack: physicalAttack,
                                knockBackForce: knockBackForce);
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