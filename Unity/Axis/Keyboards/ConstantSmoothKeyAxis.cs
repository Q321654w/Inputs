using System;
using System.Diagnostics;
using Inputs.Unity.Keys;
using UnityEngine;

namespace Inputs.Unity.Axis.Keyboards
{
    public class ConstantSmoothKeyAxis : IAxis
    {
        private readonly IKey _negativeKey;
        private readonly IKey _positiveKey;

        private readonly Stopwatch _stopwatch;

        private readonly float _positive;
        private readonly float _negative;
        private readonly float _null;
        
        private const int MILLISECOND_IN_SECOND = 1000;

        public ConstantSmoothKeyAxis(KeyCode negativeCode,
            KeyCode positiveCode) : this(-1, 1, 0, positiveCode, negativeCode)
        {
        }

        public ConstantSmoothKeyAxis(float negative,
            float positive,
            float nullValue,
            KeyCode negativeCode,
            KeyCode positiveCode) : this(negative, positive, nullValue, new Key(negativeCode), new Key(positiveCode))
        {
        }

        public ConstantSmoothKeyAxis(float negative, float positive, float nullValue, IKey negativeKey,
            IKey positiveKey) : this(negative, positive, nullValue, negativeKey, positiveKey, new Stopwatch())
        {
        }

        public ConstantSmoothKeyAxis(float negative, float positive, float nullValue, IKey negativeKey,
            IKey positiveKey, Stopwatch stopwatch)
        {
            _negative = negative;
            _positive = positive;
            _null = nullValue;
            _negativeKey = negativeKey;
            _positiveKey = positiveKey;
            _stopwatch = stopwatch;
        }

        public float Evaluate()
        {
            if (_negativeKey.Evaluate())
                return CalculateInput(_negative);

            if (_positiveKey.Evaluate())
                return CalculateInput(_positive);

            _stopwatch.Stop();
            _stopwatch.Reset();

            return _null;
        }

        private float CalculateInput(float factor)
        {
            if (!_stopwatch.IsRunning)
                RunStopWatch();

            var clampedSeconds = ClampedSeconds();
            return factor * clampedSeconds;
        }

        private float ClampedSeconds()
        {
            var seconds = _stopwatch.ElapsedMilliseconds / MILLISECOND_IN_SECOND;
            return Math.Max(Math.Min(seconds, _positive), _null);
        }

        private void RunStopWatch()
        {
            _stopwatch.Start();
        }
    }
}