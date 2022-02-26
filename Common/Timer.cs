using Inputs.Predicates;

namespace Inputs.Common
{
    public class Timer : IPredicate
    {
        private readonly float _interval;

        private float _passedTime;
        private bool _isStopped;
        private bool _timeIsUp;

        public Timer(float interval) : this(interval, false, true)
        {
        }

        public Timer(float interval, bool timeIsUp, bool isStopped)
        {
            _isStopped = isStopped;
            _interval = interval;
            _timeIsUp = timeIsUp;
        }

        public bool TimeIsUp()
        {
            return _timeIsUp;
        }
        
        public float PassedTime()
        {
            return _passedTime;
        }

        public bool IsStopped()
        {
            return _isStopped;
        }

        public void Resume()
        {
            _isStopped = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public void Update(float deltaTime)
        {
            if (_isStopped)
                return;

            _passedTime += deltaTime;

            if (_passedTime < _interval)
                return;

            _timeIsUp = true;
        }

        public void Reset()
        {
            _timeIsUp = false;
            _passedTime = 0;
        }

        public bool Execute() => TimeIsUp();
    }
}