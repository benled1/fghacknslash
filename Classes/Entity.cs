using Godot;
using System;
using System.Collections.Generic;


public partial class Entity: CharacterBody2D
{
    public bool hostile;
    public StateMachine stateMachine;
    public HitboxComponent hitboxComponent;
}