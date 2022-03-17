using UnityEngine;

namespace Inputs.Unity.Axis.Swipes
{
    public class UnClampedSwipeAxis : IAxis
    {
        private readonly int _touchIndex;

        private readonly Vector2 _axis;
        
        private Vector2 _previousValue;
        private Vector2 _touchStartPosition;
        
        private bool _hasTouchStartValue;

        public UnClampedSwipeAxis(Vector2 axis) : this(0, axis)
        {
        }

        public UnClampedSwipeAxis(int touchIndex, Vector2 axis)
        {
            _previousValue = new Vector2();
            _touchIndex = touchIndex;
            _axis = axis;
        }

        public float Evaluate()
        {
            var touches = Input.touches;

            var hasNotTouch = HasNotTouch(touches);

            if (_hasTouchStartValue && hasNotTouch)
            {
                var currentValue = _previousValue - _touchStartPosition;
                _hasTouchStartValue = false;
                return Vector3.Dot(_axis, currentValue);
            }

            var currentPosition = touches[_touchIndex].position;

            if (_hasTouchStartValue)
            {
                _previousValue = currentPosition;
                return 0;
            }

            _hasTouchStartValue = true;
            _touchStartPosition = currentPosition;
            _previousValue = currentPosition;

            return 0;
        }

        private bool HasNotTouch(Touch[] touches)
        {
            return _touchIndex >= touches.Length;
        }
    }
}