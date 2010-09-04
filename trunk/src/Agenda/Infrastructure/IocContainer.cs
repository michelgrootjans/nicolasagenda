using System;
using System.Collections.Generic;
using System.Linq;

namespace Agendas.Infrastructure
{
    public static class IocContainer
    {
        private static readonly IList<object> implementations = new List<object>();

        public static IEnumerable<T> GetImplementationsOf<T>()
        {
            return from i in implementations
                   where typeof (T).IsAssignableFrom(i.GetType())
                   select (T) i;
        }

        public static T GetImplementationOf<T>()
        {
            var matches = GetImplementationsOf<T>();
            if (matches.Count() == 1)
            {
                return matches.First();
            }
            throw new ArgumentException(string.Format("Expected 1 implementation of {0}, found {1}", typeof (T),
                                                      matches.Count()));
        }

        public static void Register(object implementation)
        {
            implementations.Add(implementation);
        }

        public static void Unregister(object implementation)
        {
            implementations.Remove(implementation);
        }
    }
}