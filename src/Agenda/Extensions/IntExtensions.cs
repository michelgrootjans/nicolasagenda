using System;

namespace Agendas.Extensions
{
    public static class IntExtensions
    {
        public static TimeSpan Uur(this int uur, int minuten)
        {
            return TimeSpan.FromHours(uur).Add(TimeSpan.FromMinutes(minuten));
        }

        public static DateTime September(this int day, int year)
        {
            return new DateTime(year, 9, day);
        }
    }
}