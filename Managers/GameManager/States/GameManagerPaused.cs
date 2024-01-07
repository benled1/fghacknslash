using Godot;

public partial class GameManagerPaused : State
{
	private GameManager gameManager;

    public override void Init()
    {
        this.gameManager = this.fsm.GetParent<GameManager>();
    }
    public override void Enter()
    {
        GD.Print("Entering Paused State");
    }

	public override void HandleInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("pause"))
		{
			if (gameManager.difficultyManager.bossfight)
			{
				fsm.TransitionTo("Boss");
			}
			else
			{
				fsm.TransitionTo("Wave");
			}
		}
    }

}
