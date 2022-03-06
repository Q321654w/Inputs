using Values;

namespace Inputs.Unity.Axis
{
    public interface IAxis : IValue<float>
    {
        new float Evaluate();
    }
}