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

        public static DateTime November(this int day, int year)
        {
            return new DateTime(year, 11, day);
        }

        public static DateTime December(this int day, int year)
        {
            return new DateTime(year, 12, day);
        }
    }
}