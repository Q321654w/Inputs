using Inputs.Unity.Keys;
using UnityEngine;

namespace Inputs.Unity.Axis.Keyboards
{
    public class ConstantRawKeyAxis : IAxis
    {
        private readonly IKey _negative;
        private readonly IKey _positive;
        
        private const float POSITIVE = 1;
        private const float NEGATIVE = -1;
        private const float NULL = 0;

        public ConstantRawKeyAxis(KeyCode negative, KeyCode positive) : this(new Key(negative), new Key(positive))
        {
        }

        public ConstantRawKeyAxis(IKey negative, IKey positive)
        {
            _negative = negative;
            _positive = positive;
        }

        public float Value()
        {
            if (_negative.Execute())
                return NEGATIVE;
            
            if (_positive.Execute())
                return POSITIVE;

            return NULL;
        }
    }
}