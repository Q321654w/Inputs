namespace Inputs.Unity.Direction.Decorator
{
    public abstract class DirectionDecorator<T> : IDirection<T>
    {
        protected readonly IDirection<T> Child;

        protected DirectionDecorator(IDirection<T> child)
        {
            Child = child;
        }

        public abstract T Direction();
    }
}