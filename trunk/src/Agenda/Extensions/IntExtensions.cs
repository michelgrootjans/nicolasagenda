using System;

namespace Agendas.Extensions
{
    public static class IntExtensions
    {
        public static DateTime September(this int day, int year)
        {
            return new DateTime(year, 9, day);
        }
    }
}