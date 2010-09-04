using System;

namespace Agenda.Extensions
{
    public static class ComparableExtensions
    {
        public static bool IsBetween<T>(this T target, T min, T max) where T : IComparable
        {
            return target.IsMoreThanOrEqualTo(min) && target.IsLessThan(max);
        }

        public static bool IsMoreThan<T>(this T target, T boundary) where T : IComparable
        {
            return target.CompareTo(boundary) > 0;
        }

        public static bool IsMoreThanOrEqualTo<T>(this T target, T boundary) where T : IComparable
        {
            return target.CompareTo(boundary) >= 0;
        }

        private static bool IsLessThan<T>(this T target, T boundary) where T : IComparable
        {
            return target.CompareTo(boundary) < 0;
        }
    }
}