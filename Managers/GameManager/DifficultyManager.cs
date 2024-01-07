using Godot;

public partial class DifficultyManager: Node2D
{
    public bool bossfight = false;
    public float difficultyScale = 0;

    private Timer difficultyTimer;

    public override void _Ready()
    {
        this.difficultyTimer = GetNode<Timer>("DifficultyTimer");
        this.difficultyTimer.Start();
    }
}