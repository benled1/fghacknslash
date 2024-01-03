using Godot;
using System;

// NOTE: this can't be technically abstract since we want to attach it to a node in the scene.
public partial class State: Node2D
{
    public StateMachine fsm;
    public virtual void Enter() {}
    public virtual void Exit() {}
    public virtual void Init() {}
    public virtual void Update(float delta) {}
    public virtual void PhysicsUpdate(float delta) {}
    public virtual void HandleInput(InputEvent @event) {}

}