using UnityEngine;

// The chain of responsibility pattern avoids coupling between the sender of a request and the recipient,
// allowing more than a single object to hear the request. Chain query handlers together and pass the request of object in until one of these succeeds in fulfilling it.
// Useful when you want to pass a request to one of many objects, without explicitly specifying the recipient
// Useful when the set of objects that will handle a request must be dynamically defined
public class Client : MonoBehaviour
{
	void Start ( )
	{
		// create calculation objects that can be chained to each other
		IChain calc1 = new AddNumbers();
		IChain calc2 = new SubtractNumbers();
		IChain calc3 = new DivideNumbers();
		IChain calc4 = new MultiplyNumbers();

		// now chain them to each other
		calc1.SetNextChain(calc2);
		calc2.SetNextChain(calc3);
		calc3.SetNextChain(calc4);

		// This is the query that gets sent to each handler
		NumbersQuery myNumbers = new NumbersQuery(3, 5, CalculationType.Add);
		calc1.Handle(myNumbers);

		// another example:
		NumbersQuery myOtherNumbers = new NumbersQuery(6, 2, CalculationType.Multiply);
		calc1.Handle(myOtherNumbers);
	}
}
