using System;

namespace Agenda.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        public static bool IsNotNullOrEmty(this string target)
        {
            return ! target.IsNullOrEmty();
        }
    }
}