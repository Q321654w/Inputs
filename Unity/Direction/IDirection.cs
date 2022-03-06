using Values;

namespace Inputs.Unity.Direction
{
    public interface IDirection<T> : IValue<T>
    {
        new T Evaluate();
    }
}