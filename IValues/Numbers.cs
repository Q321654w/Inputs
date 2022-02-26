namespace Inputs.IValues
{
    public class Numbers<T>
    {
        private readonly IValue<T> _positive;
        private readonly IValue<T> _negative;
        private readonly IValue<T> _null;

        public Numbers(IValue<T> positive, IValue<T> negative, IValue<T> nullValue)
        {
            _positive = positive;
            _negative = negative;
            _null = nullValue;
        }

        public T Positive()
        {
            return _positive.Value();
        }
        
        public T Negative()
        {
            return _negative.Value();
        }
        
        public T Null()
        {
            return _null.Value();
        }
    }
}