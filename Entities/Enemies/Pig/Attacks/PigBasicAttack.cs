using Godot;

public partial class PigBasicAttack: Attack
{
    private const float ATTACK_MULTIPLER = 1.00f;
    public PigBasicAttack(StatsComponent statsComponent)
    {
        this.attackerStatsComponent = statsComponent;
        attackTotalDamage = attackerStatsComponent.damageStats.physicalAttack * ATTACK_MULTIPLER;
    }

    public override void damage(StatsComponent statsComponent)
    {
        statsComponent.healthStats.currentHealth -= attackTotalDamage;
    }
}