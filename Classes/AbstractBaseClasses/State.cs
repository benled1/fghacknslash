using Godot;
using System;


public partial class State: Node2D
{
    // technically can't make this one abstract since we need to have it inherit from Node2D to put the 
    // derived classes onto nodes

    public StateMachine fsm;
    public virtual void Enter() {}
    public virtual void Exit() {}

    public virtual void Ready() {}
    public virtual void Update(float delta) {}

    public virtual void PhysicsUpdate(float delta) {}

    public virtual void HandleInput(InputEvent @event) {}

}