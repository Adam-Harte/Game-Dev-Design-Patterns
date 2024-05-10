public class Ghost : Monster
{
    private int health;
    private int speed;

    public Ghost(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public override Monster Clone()
    {
        return new Ghost(health, speed);
    }
}
