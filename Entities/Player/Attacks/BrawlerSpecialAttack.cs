using Godot;

public partial class BrawlerSpecialAttack: Attack
{
    private const float ATTACK_MULTIPLER = 1.50f;
    private const float KNOCKBACK_MULTIPLIER = 5.00f;
    public BrawlerSpecialAttack(StatsComponent statsComponent)
    {
        this.attackerStatsComponent = statsComponent;
        this.attackTotalDamage = this.attackerStatsComponent.damageStats.physicalAttack * ATTACK_MULTIPLER;
        this.attackKnockBackForce = this.attackerStatsComponent.damageStats.knockBackForce * KNOCKBACK_MULTIPLIER;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.healthStats.currentHealth -= attackTotalDamage;
        statsComponent.damageStats.knockBackForce = attackKnockBackForce;
    }
}