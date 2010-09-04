using System;

namespace Agenda.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object target)
        {
            return target == null;
        }

        public static bool IsNotNull(this Object target)
        {
            return !target.IsNull();
        }
    }
}