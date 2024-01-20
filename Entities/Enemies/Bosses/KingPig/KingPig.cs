using Godot;
using System;

public partial class KingPig : CharacterBody2D
{
    public StateMachine stateMachine;
    public AnimationPlayer animationPlayer;
    public int bossPhase;


    public override void _Ready()
    {
        this.bossPhase = 1;
        this.stateMachine = GetNode<StateMachine>("StateMachine_Phase1");
        this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
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
