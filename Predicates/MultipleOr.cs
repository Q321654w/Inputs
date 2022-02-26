using System.Collections.Generic;

namespace Inputs.Predicates
{
    public class MultipleOr : MultiplePredicateDecorator
    {
        public MultipleOr(IReadOnlyCollection<IPredicate> childs) : base(childs)
        {
        }

        public override bool Execute()
        {
            foreach (var predicate in Childs)
            {
                if (predicate.Execute())
                    return true;
            }

            return false;
        }
    }
}