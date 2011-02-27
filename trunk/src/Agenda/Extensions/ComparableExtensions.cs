using System;

namespace Agendas.Extensions
{
    public static class ComparableExtensions
    {
        public static bool IsBetween<T>(this T actual, T lo, T hi)
            where T : IComparable<T>
        {
            var actualIsMoreThanLo = lo.IsLessOrEqualTo(actual);
            var actualIsLessThanHi = actual.IsLessOrEqualTo(hi);
            return actualIsMoreThanLo && actualIsLessThanHi;
        }

        private static bool IsLessOrEqualTo<T>(this T actual, T hi)
            where T : IComparable<T>
        {
            var compareTo = actual.CompareTo(hi);
            return compareTo <= 0;
        }

        private static bool IsLessThan<T>(this T actual, T hi)
            where T : IComparable<T>
        {
            var compareTo = actual.CompareTo(hi);
            return compareTo < 0;
        }
    }
}