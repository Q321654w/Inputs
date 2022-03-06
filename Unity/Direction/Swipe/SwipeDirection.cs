using UnityEngine;

namespace Inputs.Unity.Direction.Swipe
{
    public class SwipeDirection : IDirection<Vector2>
    {
        private readonly int _touchIndex;

        private Vector2 _touchStartPosition;
        private Vector2 _previousValue;
        private bool _hasTouchStartValue;

        public SwipeDirection() : this(0)
        {
        }

        public SwipeDirection(int touchIndex)
        {
            _previousValue = new Vector2();
            _touchIndex = touchIndex;
        }

        public Vector2 Evaluate()
        {
            var touches = Input.touches;

            var hasNotTouch = HasNotTouch(touches);

            if (_hasTouchStartValue && hasNotTouch)
            {
                var currentValue = _previousValue - _touchStartPosition;
                _hasTouchStartValue = false;
                return currentValue;
            }

            var currentPosition = touches[_touchIndex].position;
            
            if (_hasTouchStartValue)
            {
                _previousValue = currentPosition;
                return new Vector2(0, 0);
            }
            
            _hasTouchStartValue = true;
            _touchStartPosition = currentPosition;
            _previousValue = currentPosition;
            
            return new Vector2(0, 0);
        }

        private bool HasNotTouch(Touch[] touches)
        {
            return _touchIndex >= touches.Length;
        }
    }
}