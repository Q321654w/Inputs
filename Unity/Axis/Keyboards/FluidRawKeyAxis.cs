﻿using Inputs.IValues;
using Inputs.Unity.Keys;
using UnityEngine;

namespace Inputs.Unity.Axis.Keyboards
{
    public class FluidRawKeyAxis : IAxis
    {
        private readonly IKey _negative;
        private readonly IKey _positive;

        private readonly Numbers<float> _numbers;

        public FluidRawKeyAxis(KeyCode negative, KeyCode positive) : this(new Key(negative), new Key(positive))
        {
        }
        
        public FluidRawKeyAxis(IKey negative, IKey positive) : this(negative,positive,
            new Numbers<float>(
                new DefaultValue<float>(1),
                new DefaultValue<float>(-1),
                new DefaultValue<float>(0)))
        {
        }

        public FluidRawKeyAxis(IKey negative, IKey positive, Numbers<float> numbers)
        {
            _negative = negative;
            _positive = positive;
            _numbers = numbers;
        }

        public float Value()
        {
            if (_negative.Execute())
                return _numbers.Negative();
            
            if (_positive.Execute())
                return _numbers.Positive();

            return _numbers.Null();
        }
    }
}