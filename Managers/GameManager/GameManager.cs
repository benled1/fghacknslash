using Godot;
using System;

public partial class GameManager : Node2D
{

	public DifficultyManager difficultyManager;
	private StateMachine stateMachine;


    public override void _Ready()
    {
        this.stateMachine = GetNode<StateMachine>("StateMachine");
		this.difficultyManager = GetNode<DifficultyManager>("DifficultyManager");

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
