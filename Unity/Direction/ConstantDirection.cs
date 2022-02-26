using UnityEngine;

namespace Inputs.Unity.Direction
{
    public class ConstantDirection : IDirection<Vector2>
    {
        private readonly float _xDirection;
        private readonly float _yDirection;

        public ConstantDirection(float xDirection, float yDirection)
        {
            _xDirection = xDirection;
            _yDirection = yDirection;
        }

        public Vector2 Evaluate()
        {
            return new Vector2(_xDirection, _yDirection);
        }
    }
}