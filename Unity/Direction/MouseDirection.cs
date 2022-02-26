using UnityEngine;

namespace Inputs.Unity.Direction
{
    public class MouseDirection : IDirection<Vector2>
    {
        private Vector3 _lastMousePosition;

        public MouseDirection()
        {
            _lastMousePosition = new Vector3();
        }

        public Vector2 Evaluate()
        {
            var currentMousePosition = Input.mousePosition;
            var direction = currentMousePosition - _lastMousePosition;

            _lastMousePosition = currentMousePosition;

            return direction;
        }
    }
}