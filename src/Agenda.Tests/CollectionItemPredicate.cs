using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace Agenda.Tests
{
    public class CollectionItemPredicate<T> : Constraint, IResolveConstraint
    {
        private readonly Func<T, bool> predicate;

        public CollectionItemPredicate(Func<T, bool> predicate)
        {
            this.predicate = predicate;
        }

        public override bool Matches(object actual)
        {
            if (!(actual is IEnumerable<T>)) return false;

            var list = actual as IEnumerable<T>;
            return list.Any(predicate);
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.Write("Collection did not contain the expected element");
        }

        public Constraint Resolve()
        {
            return this;
        }
    }
}