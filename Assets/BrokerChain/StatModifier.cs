using UnityEngine;

// Abstract class to represent any modifier to be used by the broker. This contains the Handle method which is called in response to the event the broker is managing
public abstract class StatModifier : MonoBehaviour
{
    public abstract void Handle(object sender, Query query);
}
