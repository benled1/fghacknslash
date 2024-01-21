using Godot;


public partial class KingPigIdle : State
{
    KingPig kingPig;

    public override void Init()
    {
        this.kingPig = this.fsm.GetParent<KingPig>();
    }
    public override void Enter() 
    {
        this.kingPig.animationPlayer.Play("Idle");
    }
    public override void Exit()
	{
	}

	public override void Update(float delta)
    {
    }

	public override void PhysicsUpdate(float delta)
	{
        Vector2 velocity = kingPig.Velocity;
        velocity.X = 0;

        velocity = _applyGravity(velocity, delta);

        kingPig.Velocity = velocity;
        kingPig.MoveAndSlide();
	}

	private Vector2 _applyGravity(Vector2 velocity, float delta)
	{
		if (!kingPig.IsOnFloor())
        {
            velocity.Y += kingPig.statsComponent.movementStats.gravity * delta;
        }
		return velocity;
	}
}