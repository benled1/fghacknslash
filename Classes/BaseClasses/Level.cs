

public class Level
{
    public float currentXp;
    public float maxXP;
    public int currentLevel;

    public virtual void levelUp() {}

    public void gainXP(float value)
    {
        currentXp += value;
        if (currentXp >= maxXP)
        {
            levelUp();
            currentXp -= maxXP;
            maxXP *= 1.5f;
        }
    }

}