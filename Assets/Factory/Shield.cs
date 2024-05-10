public class Shield : Weapon
{
    private int defense { get; set; }

    public Shield(int damage, int defense) : base(damage)
    {
        this.defense = defense;
    }
}
