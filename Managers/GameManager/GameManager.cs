using Godot;
using System;

public partial class GameManager : Node2D
{
	public DifficultyManager difficultyManager;
    public LevelManager levelManager;
	private StateMachine stateMachine;


    public override void _Ready()
    {
        this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.difficultyManager = GetNode<DifficultyManager>("DifficultyManager");
        this.levelManager = GetNode<LevelManager>("LevelManager");

		this.stateMachine.Init();
        this.levelManager.loadLevel("res://Scenes/Levels/TestLevel/TestWorldWave.tscn");
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
