using System;
using Values;

namespace Inputs.Unity.Axis.Decorators
{
    public class FluidClampAxis : AxisDecorator
    {
        private readonly IRange<IValue<float>> _numbers;

        public FluidClampAxis(IAxis childAxis, IRange<IValue<float>> numbers) : base(childAxis)
        {
            _numbers = numbers;
        }

        public override float Input()
        {
            var value = ChildAxis.Input();
            var max = _numbers.Max().Evaluate();
            var min = _numbers.Min().Evaluate();

            return Math.Max(Math.Min(value, max), min);
        }
    }
}