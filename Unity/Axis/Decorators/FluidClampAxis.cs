using System;

namespace Inputs.Unity.Axis.Decorators
{
    public class FluidClampAxis : AxisDecorator
    {
        private readonly Range<float> _numbers;

        public FluidClampAxis(Range<float> numbers)
        {
            _numbers = numbers;
        }

        public override float Value()
        {
            return Math.Min(Math.Max(ChildAxis.Value(), _numbers.Max), _numbers.Min);
        }
    }
}