namespace Inputs.Predicates
{
    public class And : PredicateDecorator
    {
        private IPredicate _predicate;
        
        public And(IPredicate child, IPredicate predicate) : base(child)
        {
            _predicate = predicate;
        }

        public override bool Execute()
        {
            return _predicate.Execute() && Child.Execute();
        }
    }
}