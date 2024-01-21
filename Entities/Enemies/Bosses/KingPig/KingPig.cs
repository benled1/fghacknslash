using Godot;
using System;

public partial class KingPig : Boss
{

    public override void _Ready()
    {
        // define initial stats
        this.maxHealth = 50;
        this.direction = -1;
        this.moveSpeed = 100;
        this.jumpVelocity = 50;
        this.physicalAttack = 10;
        this.staggerable = false;

        this.stateMachine = GetNode<StateMachine>("StateMachine");
        this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        this.statsComponent = GetNode<StatsComponent>("StatsComponent");

        // init the statsComponent with the initial stats
        this.statsComponent.Init(maxHealth: maxHealth,
                                direction: direction,
                                moveSpeed: moveSpeed,
                                jumpVelocity: jumpVelocity,
                                physicalAttack: physicalAttack,
                                staggerable: staggerable);

        // init the statemachine
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
