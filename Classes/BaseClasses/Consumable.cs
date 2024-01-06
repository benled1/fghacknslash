using Godot;


public partial class Consumable: CharacterBody2D
{
    public bool tracking = false;
    public Player player;

    public override void _PhysicsProcess(double delta)
    {
        
        if (this.tracking)
        {
            Vector2 velocity = this.Velocity;
            velocity = _trackPlayer(velocity);
            this.Velocity = velocity;
            this.MoveAndSlide();
        }
    }
    protected virtual void triggerEffect(Player player) {}
    public void enableTracking(Player player)
    {
        this.player = player;
        this.tracking = true;
    }

    public void disableTracking()
    {
        this.Velocity = Vector2.Zero;
        this.player = null;
        this.tracking = false;
    }
    private Vector2 _trackPlayer(Vector2 velocity)
    {
        Vector2 addedVelocity = (this.player.Position - this.Position).Normalized() * 10;
        velocity += addedVelocity;
        return velocity;
    }


    
}