using System;

namespace Agendas.Extensions
{
    public static class ComparableExtensions
    {
        public static bool IsBetween(this IComparable actual, IComparable lo, IComparable hi)
        {
            return lo.IsLessOrEqualTo(actual) || actual.IsLessThan(hi);
        }

        private static bool IsLessOrEqualTo(this IComparable actual, IComparable hi)
        {
            var compareTo = actual.CompareTo(hi);
            return compareTo <= 0;
        }

        private static bool IsLessThan(this IComparable actual, IComparable hi)
        {
            var compareTo = actual.CompareTo(hi);
            return compareTo < 0;
        }
    }
}