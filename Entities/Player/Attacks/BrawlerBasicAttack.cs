using Godot;

public partial class BrawlerBasicAttack: Attack
{
    private const float ATTACK_MULTIPLER = 1.00f;
    private const float KNOCKBACK_MULTIPLIER = 1.00f;

    public BrawlerBasicAttack(StatsComponent statsComponent)
    {
        // attack specific multiplier

        this.attackerStatsComponent = statsComponent;
        this.attackTotalDamage = attackerStatsComponent.damageStats.physicalAttack * ATTACK_MULTIPLER;
        this.attackKnockBackForce = attackerStatsComponent.damageStats.knockBackForce * KNOCKBACK_MULTIPLIER;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.healthStats.currentHealth -= attackTotalDamage;
        statsComponent.damageStats.knockBackForce = attackKnockBackForce;
    }
}