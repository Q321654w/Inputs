using UnityEngine;
using Values;

namespace Inputs.Unity.Direction
{
    public class ConstantDirection : IDirection<Vector2>
    {
        private readonly IValue<Vector2> _value;

        public ConstantDirection(IValue<Vector2> value)
        {
            _value = value;
        }

        public Vector2 Evaluate()
        {
            return _value.Evaluate();
        }
    }
}