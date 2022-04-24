namespace Inputs.Unity.Axis.Decorators
{
    public abstract class AxisDecorator : IAxis
    {
        protected readonly IAxis ChildAxis;

        public AxisDecorator(IAxis childAxis)
        {
            ChildAxis = childAxis;
        }

        public abstract float Input();
    }
}