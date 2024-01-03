using Godot;

public partial class PigBasicAttack: Attack
{
    public PigBasicAttack()
    {
        // for now just hardcode the total damage
        // in the future this constructor should take the player's attack damage stats and modifiers through 
        // the constructor
        totalDamage = 10;
        knockBackForce = 0;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.currentHealth -= 10;

        GD.Print("HIT: new health = " + statsComponent.currentHealth);
    }
}