using Collections.Predicates.WithOutParameters;

namespace Inputs.Unity.Keys
{
    public interface IKey : IPredicate
    {
        new bool Evaluate();
    }
}