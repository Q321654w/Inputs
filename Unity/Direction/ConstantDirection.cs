using UnityEngine;

namespace Inputs.Unity.Direction
{
    public class ConstantDirection : IDirection<Vector2>
    {
        private readonly Vector2 _value;

        public ConstantDirection(Vector2 value)
        {
            _value = value;
        }

        public Vector2 Direction()
        {
            return _value;
        }
    }
}