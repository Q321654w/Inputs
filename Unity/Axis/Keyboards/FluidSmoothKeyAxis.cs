using System;
using System.Diagnostics;
using Inputs.Unity.Keys;
using UnityEngine;
using Values;

namespace Inputs.Unity.Axis.Keyboards
{
    public class FluidSmoothKeyAxis : IAxis
    {
        private readonly IKey _negative;
        private readonly IKey _positive;

        private readonly Numbers<float> _numbers;
        private readonly Stopwatch _stopwatch;

        private const int MILLISECOND_IN_SECOND = 1000;

        public FluidSmoothKeyAxis(KeyCode negative, KeyCode positive) : this(new Key(negative), new Key(positive))
        {
        }
        
        public FluidSmoothKeyAxis(IKey negative, IKey positive) : this(negative,positive,
            new Numbers<float>(
                new DefaultValue<float>(1),
                new DefaultValue<float>(-1),
                new DefaultValue<float>(0)))
        {
        }

        public FluidSmoothKeyAxis(IKey negative, IKey positive, Numbers<float> numbers) : this(negative,
            positive, numbers, new Stopwatch())
        {
        }

        public FluidSmoothKeyAxis(IKey negative, IKey positive, Numbers<float> numbers,
            Stopwatch stopwatch)
        {
            _negative = negative;
            _positive = positive;
            _numbers = numbers;
            _stopwatch = stopwatch;
        }

        public float Evaluate()
        {
            if (_negative.Evaluate())
                return CalculateInput(_numbers.Negative());

            if (_positive.Evaluate())
                return CalculateInput(_numbers.Positive());

            _stopwatch.Stop();
            _stopwatch.Reset();

            return _numbers.Null();
        }

        private float CalculateInput(float factor)
        {
            if (!_stopwatch.IsRunning)
                RunStopwatch();

            var clampedSeconds = ClampedSeconds();
            return factor * clampedSeconds;
        }

        private float ClampedSeconds()
        {
            var seconds = _stopwatch.ElapsedMilliseconds / MILLISECOND_IN_SECOND;
            return Math.Max(Math.Min(seconds, 1), 0);
        }

        private void RunStopwatch()
        {
            _stopwatch.Start();
        }
    }
}