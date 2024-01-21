using Godot;

public partial class Player : CharacterBody2D
{

    // STATS COMPONENT INITIAL VALUES
    private float maxHealth = 100;
	private float moveSpeed = 250;
	private float jumpVelocity = 400;
    private float physicalAttack = 10;
    private float knockBackForce = 10;
    private bool staggerable = false;

    
    // NODE REFERENCES
    public StateMachine stateMachine;
    public AnimationPlayer animationPlayer;
    public Node2D spriteContainer;
    public GameManager gameManager;
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
        this.sprite = GetNode<Sprite2D>("SpriteContainer/Player");
        this.gameManager = GetNode<GameManager>("/root/Gameplay/GameManager");
        this.iFrames = GetNode<Timer>("IFrames");
        this.level = new PlayerLevel(this);

        // set the initial spawn position (this only runs for entrypoint levels)
        this.Position = this.gameManager.levelManager.currentLevelInfo.playerSpawnLocation;
        this.statsComponent.Init(maxHealth: maxHealth, 
                                moveSpeed: moveSpeed, 
                                jumpVelocity: jumpVelocity,
                                physicalAttack: physicalAttack,
                                knockBackForce: knockBackForce,
                                staggerable: staggerable);
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