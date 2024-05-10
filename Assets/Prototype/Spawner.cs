// This Spawner class demonstrates the benefits of the prototype pattern
// if we went typical OOP we would have a separate Spawner class for each type of monster referencing that monster and creating instances of it on spawn
// However now with the prototype pattern we have defined a clone method which all Monster child classes implement so now we just need one monster Spawner class
// that calls the Monster CLone method to spawn new instances

public class Spawner
{
    private Monster prototype;

    public Spawner(Monster prototype) {
        this.prototype = prototype;
    }

    public void Spawn() {
        prototype.Clone();
    }
}