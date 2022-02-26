using UnityEngine;

namespace Inputs.Unity.Axis.Mouses
{
    public class UnClampedMouseAxis : IAxis
    {
        private readonly Vector3 _axis;

        private Vector3 _previousValue;

        public UnClampedMouseAxis(Vector3 axis)
        {
            _previousValue = new Vector3();
            _axis = axis;
        }
        
        public float Value()
        {
            var currentValue = Input.mousePosition;
            var projection = Vector3.Project(currentValue, _axis);

            var distance = Vector2.Distance(projection, _previousValue);
            _previousValue = currentValue;

            return distance;
        }
    }
}