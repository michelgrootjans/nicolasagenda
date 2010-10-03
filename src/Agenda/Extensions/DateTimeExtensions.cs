using System;

namespace Agendas.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime At(this DateTime date, int hour)
        {
            return date.Date.AddHours(hour);
        }

        public static DateTime At(this DateTime date, int hour, int minutes)
        {
            return date.At(hour).AddMinutes(minutes);
        }

        public static bool IsWeekendDay(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}