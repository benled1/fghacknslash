using Godot;
using System;


public class Attack
{
    protected StatsComponent attackerStatsComponent;
    
    protected float attackTotalDamage;
    protected float attackKnockBackForce;

    public virtual void damage(StatsComponent statsComponent) {}
}


