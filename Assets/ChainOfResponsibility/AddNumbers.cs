using UnityEngine;

public class AddNumbers : IChain
{
    protected IChain nextInChain;

    public void SetNextChain(IChain nextChain)
    {
        this.nextInChain = nextChain;
    }

    public void Handle(NumbersQuery request)
    {
        if(request.calculationWanted == CalculationType.Add)
        {
            Debug.Log("Adding: " + request.number1 + " + " + request.number2 + " = " + (request.number1 + request.number2).ToString());
        }
        else if(nextInChain != null)
            nextInChain.Handle(request);
        else
            Debug.Log ("Handling of request failed: " + request.calculationWanted);
    }
}
