using UnityEngine;

// The Strategy pattern allows us to define a base type for a group of things that another class can then call without needing to know the implementation details of the child class types
// This helps decouple things as the class needing to use a strategy only needs to care about the base abstract Strategy class and not concrete implementations
// This avoid code smells such as lots of if/else conditions trying to execute different strategies based on child object types.
public abstract class SpellStrategy
{
    public abstract void CastSpell(Transform origin);
}
