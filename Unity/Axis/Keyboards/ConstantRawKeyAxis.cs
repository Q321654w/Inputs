using Inputs.Unity.Keys;
using UnityEngine;

namespace Inputs.Unity.Axis.Keyboards
{
    public class ConstantRawKeyAxis : IAxis
    {
        private readonly IKey _negativeKey;
        private readonly IKey _positiveKey;

        private readonly float _positive;
        private readonly float _negative;
        private readonly float _null;

        public ConstantRawKeyAxis(KeyCode negativeCode, KeyCode positiveCode) : this(
            -1, 
            1, 
            0, 
            new Key(negativeCode), 
            new Key(positiveCode))
        {
        }
        
        public ConstantRawKeyAxis(IKey negativeKey, IKey positiveKey) : this(
            -1, 
            1, 
            0, 
            negativeKey,
            positiveKey)
        {
        }

        public ConstantRawKeyAxis(float negative, float positive, float nullValue, IKey negativeKey, IKey positiveKey)
        {
            _positive = positive;
            _negative = negative;
            _null = nullValue;
            _negativeKey = negativeKey;
            _positiveKey = positiveKey;
        }

        public float Input()
        {
            if (_negativeKey.HasInput())
                return _negative;

            if (_positiveKey.HasInput())
                return _positive;

            return _null;
        }
    }
}