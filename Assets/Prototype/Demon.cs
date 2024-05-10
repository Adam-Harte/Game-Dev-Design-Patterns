public class Demon : Monster
{
    private int health;
    private int speed;

    public Demon(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public override Monster Clone()
    {
        return new Demon(health, speed);
    }
}