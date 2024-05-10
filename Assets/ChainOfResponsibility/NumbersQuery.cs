using UnityEngine;

// We use this NumbersQuery as an example query to be passed to the calculation chain
// to figure out what we want to do with it (which is stored in CalculationType/calculationWanted)
public class NumbersQuery : MonoBehaviour
{
    // some numbers:
    public int number1 { get; protected set; }
    public int number2 { get; protected set; }

    // here we store in this object what we want to do with it to let the chain figure out who is responsible for it
    public CalculationType calculationWanted { get; protected set; }

    public NumbersQuery(int num1, int num2, CalculationType calcWanted)
    {
        this.number1 = num1;
        this.number2 = num2;
        this.calculationWanted = calcWanted;
    }
}

public enum CalculationType
	{
		Add,
		Substract,
		Divide,
		Multiply
	};
