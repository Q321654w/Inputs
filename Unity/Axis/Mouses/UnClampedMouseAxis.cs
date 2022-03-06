using UnityEngine;

namespace Inputs.Unity.Axis.Mouses
{
    public class UnClampedMouseAxis : IAxis
    {
        private readonly Vector3 _axis;

        private Vector3 _previousValue;

        public UnClampedMouseAxis(Vector3 axis)
        {
            _previousValue = Input.mousePosition;
            _axis = axis;
        }
        
        public float Evaluate()
        {
            var currentPosition = Input.mousePosition;
            var currentValue = currentPosition - _previousValue;
            var projection = Vector3.Dot(_axis, currentValue);
            
            _previousValue = currentPosition;

            return projection;
        }
    }
}