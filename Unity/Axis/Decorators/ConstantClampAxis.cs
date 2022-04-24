using System;

namespace Inputs.Unity.Axis.Decorators
{
    public class ConstantClampAxis : AxisDecorator
    {
        private readonly float _positive;
        private readonly float _negative;

        public ConstantClampAxis(IAxis childAxis) : this(-1, 1, childAxis)
        {
        }

        public ConstantClampAxis(float negative, float positive, IAxis childAxis) : base(childAxis)
        {
            _negative = negative;
            _positive = positive;
        }

        public override float Input()
        {
            return Math.Max(Math.Min(ChildAxis.Input(), _positive), _negative);
        }
    }
}