using Godot;
using System;


public partial class Attack
{
    public float totalDamage;
    public float knockBackForce;

    public virtual void damage(StatsComponent statsComponent) {}
}


