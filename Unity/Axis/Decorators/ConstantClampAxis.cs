using System;

namespace Inputs.Unity.Axis.Decorators
{
    public class ConstantClampAxis : AxisDecorator
    {
        private const float POSITIVE = 1;
        private const float NEGATIVE = -1;
        
        public override float Value()
        {
            return Math.Min(Math.Max(ChildAxis.Value(), POSITIVE), NEGATIVE);
        }
    }
}