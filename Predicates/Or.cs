namespace Inputs.Predicates
{
    public class Or : PredicateDecorator
    {
        private IPredicate _predicate;
        
        public Or(IPredicate child, IPredicate predicate) : base(child)
        {
            _predicate = predicate;
        }

        public override bool Execute()
        {
            return _predicate.Execute() || Child.Execute();
        }
    }
}