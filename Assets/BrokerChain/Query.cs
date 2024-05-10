using UnityEngine;

// The Query class is responsible for setting up the Query that will be passed into a handler/modifier
// which will then decide what to do with it based on the Query information
public class Query : MonoBehaviour
{
    public readonly StatType StatType;
    public int Value;

    public Query(StatType statType, int value) {
        StatType = statType;
        Value = value;
    }
}
