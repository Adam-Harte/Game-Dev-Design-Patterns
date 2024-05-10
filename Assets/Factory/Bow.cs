public class Bow : Weapon
{
    private int range { get; set; }
    private int fireRate { get; set; }


    public Bow(int damage, int range, int fireRate) : base(damage)
    {
        this.range = range;
        this.fireRate = fireRate;
    }
    
}
