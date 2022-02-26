namespace Inputs.IValues
{
    public class DefaultValue<T> : IValue<T>
    {
        private readonly T _value;

        public DefaultValue(T value)
        {
            _value = value;
        }

        public T Value()
        {
            return _value;
        }
    }
}