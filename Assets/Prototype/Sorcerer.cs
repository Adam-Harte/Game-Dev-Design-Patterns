public class Sorcerer : Monster
{
    private int health;
    private int speed;

    public Sorcerer(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public override Monster Clone()
    {
        return new Sorcerer(health, speed);
    }
}