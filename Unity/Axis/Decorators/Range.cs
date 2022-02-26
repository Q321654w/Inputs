namespace Inputs.Unity.Axis.Decorators
{
    public readonly struct Range<T>
    {
        private readonly T _min;
        private readonly T _max;

        public Range(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public T Min => _min;
        public T Max => _max;
    }
}