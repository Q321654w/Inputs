using UnityEngine;

namespace Inputs.Unity.Axis.Mouses
{
    public class UnClampedMouseAxis : IAxis
    {
        private readonly Vector2 _axis;

        private Vector3 _previousValue;

        public UnClampedMouseAxis(Vector3 axis)
        {
            _previousValue = UnityEngine.Input.mousePosition;
            _axis = axis;
        }
        
        public float Input()
        {
            var currentPosition = UnityEngine.Input.mousePosition;
            var currentValue = currentPosition - _previousValue;
            var projection = Vector3.Dot(_axis, currentValue);
            
            _previousValue = currentPosition;

            return projection;
        }
    }
}