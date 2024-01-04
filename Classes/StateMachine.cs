using Godot;
using System;
using System.Collections.Generic;


public partial class StateMachine: Node
{
    [Export] public NodePath initialState;

    private Dictionary<string, State> _states;
    public State currentState;

    public void Init()
    {
        _states = new Dictionary<string, State>();
        foreach (Node node in GetChildren())
        {
            if (node is State s)
            {
                _states[node.Name] = s;
                s.fsm = this;
                s.Init();
                s.Exit(); // resets all states
            }
        }

        currentState = GetNode<State>(initialState);
        currentState.Enter();
    }

    public void Update(double delta)
    {
        currentState.Update((float)delta);
    }

    public void PhysicsUpdate(double delta)
    {
        currentState.PhysicsUpdate((float)delta);
    }

    public void HandleInput(InputEvent @event)
    {
        currentState.HandleInput(@event);
    }

    public void TransitionTo(string key)
    {
        if (!_states.ContainsKey(key) || currentState == _states[key])
        {
            return;
        }

        currentState.Exit();
        currentState = _states[key];
        currentState.Enter();
    }
}