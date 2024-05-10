using UnityEngine;

public class MultiplyNumbers : IChain
{
    protected IChain nextInChain;

    public void SetNextChain(IChain nextChain)
    {
        this.nextInChain = nextChain;
    }

    public void Handle(NumbersQuery request)
    {
        if(request.calculationWanted == CalculationType.Multiply)
        {
            Debug.Log("Multiplying: " + request.number1 + " * " + request.number2 + " = " + (request.number1 * request.number2).ToString());
        }
        else if(nextInChain != null)
            nextInChain.Handle(request);
        else
            Debug.Log ("Handling of request failed: " + request.calculationWanted);
    }
}

