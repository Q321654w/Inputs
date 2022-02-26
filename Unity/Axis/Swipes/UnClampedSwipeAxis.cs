using UnityEngine;

namespace Inputs.Unity.Axis.Swipes
{
    public class UnClampedSwipeAxis : IAxis
    {
        private readonly int _touchIndex;

        private Vector2 _previousValue;
        private readonly Vector2 _axis;

        public UnClampedSwipeAxis(Vector2 axis) : this(0, axis)
        {
        }

        public UnClampedSwipeAxis(int touchIndex, Vector2 axis)
        {
            _previousValue = new Vector2();
            _touchIndex = touchIndex;
            _axis = axis;
        }

        public float Value()
        {
            var currentValue = Input.touches[_touchIndex].position;
            var projection = Vector3.Project(currentValue, _axis);

            var distance = Vector2.Distance(projection, _previousValue);
            _previousValue = currentValue;

            return distance;
        }
    }
}