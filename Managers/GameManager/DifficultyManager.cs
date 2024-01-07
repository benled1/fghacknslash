using Godot;

public partial class DifficultyManager: Node2D
{
    public bool bossfight = false;
    public float difficultyScale;
    private Timer difficultyTimer;

    public override void _Ready()
    {
        this.difficultyTimer = GetNode<Timer>("DifficultyTimer");
        this.difficultyTimer.Start();
    }

    public override void _Process(double delta)
    {
        this.difficultyScale = 100/(float)this.difficultyTimer.TimeLeft;
    }
}