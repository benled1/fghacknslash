using Godot;

public class PlayerLevel: Level
{
    public Player player;
    public PlayerLevel(Player player)
    {
        this.currentXp = 0;
        this.maxXP = 10;
        this.currentLevel = 1;
        this.player = player;
    }

    protected override void levelUp()
    {
        this.currentLevel += 1;
        GD.Print(this.currentLevel);
        player.statsComponent.maxHealth += 10;
        player.statsComponent.moveSpeed += 2;
    }
}