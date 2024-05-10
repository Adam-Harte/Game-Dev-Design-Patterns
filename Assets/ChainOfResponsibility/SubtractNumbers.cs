using UnityEngine;

public class SubtractNumbers : IChain
{
		protected IChain nextInChain;

		public void SetNextChain(IChain nextChain)
		{
			this.nextInChain = nextChain;
		}

		public void Handle(NumbersQuery request)
		{
			if(request.calculationWanted == CalculationType.Substract)
			{
				Debug.Log("Substracting: " + request.number1 + " - " + request.number2 + " = " + (request.number1 - request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Handle(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}
