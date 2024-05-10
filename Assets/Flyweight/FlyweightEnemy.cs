public class FlyweightEnemy : Flyweight
{
    new FlyweightEnemySettings settings => (FlyweightEnemySettings) base.settings;
}
