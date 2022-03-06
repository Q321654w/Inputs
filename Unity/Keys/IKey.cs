using Predicate;

namespace Inputs.Unity.Keys
{
    public interface IKey : IPredicate
    {
        new bool Evaluate();
    }
}