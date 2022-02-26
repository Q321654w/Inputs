namespace Inputs.Unity.Axis.Decorators
{
    public abstract class AxisDecorator : IAxis
    {
        protected IAxis ChildAxis;

        public abstract float Value();
    }
}