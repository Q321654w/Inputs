using System.Collections.Generic;

namespace Inputs.Predicates
{
    public class MultipleAnd : MultiplePredicateDecorator
    {
        public MultipleAnd(IReadOnlyCollection<IPredicate> childs) : base(childs)
        {
        }

        public override bool Execute()
        {
            foreach (var predicate in Childs)
            {
                if (!predicate.Execute())
                    return false;
            }

            return true;
        }
    }
}