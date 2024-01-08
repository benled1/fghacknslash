using Godot;



public class PigLevel: Level
{
    public Pig pig;

    public PigLevel(Pig pig)
    {
        this.currentXp = 0;
        this.maxXP = 10;
        this.currentLevel = 1;
        this.pig = pig;
    }

    public override void levelUp()
    {   
        this.currentLevel += 1;
        pig.statsComponent.healthStats.maxHealth += 10;
        pig.statsComponent.movementStats.moveSpeed += 2;
        pig.statsComponent.damageStats.physicalAttack += 2;
        GD.Print("LEVELING UP TO " + this.currentLevel);
    }

}