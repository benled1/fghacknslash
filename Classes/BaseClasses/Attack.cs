using Godot;
using System;


public class Attack
{
    protected StatsComponent attackerStatsComponent;
    
    // the final values after all modifiers and multipliers are applied
    protected float attackTotalDamage;
    protected float attackKnockBackForce;

    public virtual void damage(StatsComponent statsComponent) {}
}


