using System;

namespace Agenda.Extensions
{
    public static class IntExtensions
    {
        public static DateTime September(this int day, int year)
        {
            return new DateTime(year, 9, day);
        }

        public static DateTime Oktober(this int day, int year)
        {
            return new DateTime(year, 10, day);
        }
    }
}