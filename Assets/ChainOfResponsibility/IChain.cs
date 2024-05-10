// the Handler
public interface IChain
{
    void SetNextChain(IChain nextChain); // to be called when calulcation fails
    void Handle(NumbersQuery numbersQuery); // try to handle event
}
