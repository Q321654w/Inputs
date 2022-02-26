using System.Collections.Generic;

namespace Inputs.Predicates
{
    public abstract class MultiplePredicateDecorator : IPredicate
    {
        protected IEnumerable<IPredicate> Childs;

        protected MultiplePredicateDecorator(IEnumerable<IPredicate> childs)
        {
            Childs = childs;
        }

        public abstract bool Execute();
    }
}