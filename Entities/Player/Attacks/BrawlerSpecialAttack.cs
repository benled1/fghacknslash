using Godot;

public partial class BrawlerSpecialAttack: Attack
{
    public BrawlerSpecialAttack()
    {
        // for now just hardcode the total damage
        // in the future this constructor should take the player's attack damage stats and modifiers through 
        // the constructor
        totalDamage = 10;
        knockBackForce = 80;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.currentHealth -= totalDamage;
        statsComponent.knockBackForce = knockBackForce;
    }
}