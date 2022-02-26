namespace Inputs.Predicates
{
    public abstract class PredicateDecorator : IPredicate
    {
        protected IPredicate Child;

        protected PredicateDecorator(IPredicate child)
        {
            Child = child;
        }

        public abstract bool Execute();
    }
}