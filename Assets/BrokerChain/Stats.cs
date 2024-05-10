public enum StatType { Attack, Defense }

// Example of using the BrokerChain pattern where we have the stats class using the broker to manage handling performing query events
// and also being able to add more chain/modifier callbacks to the event or chain/modifier to the list
// This demonstrates decoupling the query and chain/modifier objects as they can now all be handled by the broker and you only need a reference
// to a broker instance to use the pattern instead of references to all the different queries, chains/modifers
public class Stats {
    readonly StatsBroker broker;
    readonly BaseStats baseStats;
    
    public StatsBroker Broker => broker;
    
    public int Attack {
        get {
            var q = new Query(StatType.Attack, baseStats.attack);
            broker.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public int Defense {
        get {
            var q = new Query(StatType.Defense, baseStats.defense);
            broker.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public Stats(StatsBroker broker, BaseStats baseStats) {
        this.broker = broker;
        this.baseStats = baseStats;
    }
    
    public override string ToString() => $"Attack: {Attack}, Defense: {Defense}";
}
