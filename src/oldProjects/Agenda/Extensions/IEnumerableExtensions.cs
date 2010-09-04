using System;
using System.Collections.Generic;

namespace Agenda.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var t in list)
                action(t);
        }

        public static IEnumerable<To> ConvertAll<From, To>(this IEnumerable<From> list, Converter<From, To> converter)
        {
            return new List<From>(list).ConvertAll(converter);
        }

        public static IEnumerable<T> RemoveAll<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            var result = new List<T>(list);
            result.RemoveAll(predicate);
            return result;
        }
    }
}