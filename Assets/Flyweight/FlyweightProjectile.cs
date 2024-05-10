public class FlyweightProjectile : Flyweight
{
    new FlyweightProjectileSettings settings => (FlyweightProjectileSettings) base.settings;
}
