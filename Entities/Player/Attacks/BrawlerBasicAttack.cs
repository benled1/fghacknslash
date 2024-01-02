


public partial class BrawlerBasicAttack: Attack
{
    public BrawlerBasicAttack()
    {
        // for now just hardcode the total damage
        // in the future this constructor should take the player's attack damage stats and modifiers through 
        // the constructor
        totalDamage = 10;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.currentHealth -= totalDamage;
    }
}