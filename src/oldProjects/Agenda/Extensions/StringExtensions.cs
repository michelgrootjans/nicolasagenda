using System;

namespace Agenda.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string target)
        {
            return string.Empty.Equals(target);
        }

        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        public static bool IsNotNullOrEmpty(this string target)
        {
            return ! target.IsNullOrEmpty();
        }
    }
}