using System;
using System.Diagnostics;
using Inputs.Unity.Keys;
using UnityEngine;

namespace Inputs.Unity.Axis.Keyboards
{
    public class ConstantSmoothKeyAxis : IAxis
    {
        private readonly IKey _negative;
        private readonly IKey _positive;

        private readonly Stopwatch _stopwatch;

        private const int MILLISECOND_IN_SECOND = 1000;
        private const float POSITIVE = 1;
        private const float NEGATIVE = -1;
        private const float NULL = 0;

        public ConstantSmoothKeyAxis(KeyCode negative, KeyCode positive) : this(new Key(negative), new Key(positive))
        {
        }
        
        public ConstantSmoothKeyAxis(IKey negative, IKey positive) : this(negative, positive, new Stopwatch())
        {
        }

        public ConstantSmoothKeyAxis(IKey negative, IKey positive, Stopwatch stopwatch)
        {
            _negative = negative;
            _positive = positive;
            _stopwatch = stopwatch;
        }

        public float Value()
        {
            if (_negative.Execute())
                CalculateInput(NEGATIVE);

            if (_positive.Execute())
                return CalculateInput(POSITIVE);
            
            _stopwatch.Stop();
            _stopwatch.Reset();

            return NULL;
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
            return Math.Max(Math.Min(seconds, 0), 1);
        }

        private void RunStopWatch()
        {
            _stopwatch.Start();
        }
    }
}