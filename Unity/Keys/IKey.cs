using Inputs.Predicates;

namespace Inputs.Unity.Keys
{
    public interface IKey : IPredicate
    {
        bool Execute();
    }
}