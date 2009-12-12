using System;

namespace Agenda.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime At(this DateTime date, int hour)
        {
            return At(date, hour, 0);
        }

        public static DateTime At(this DateTime date, int hour, int minutes)
        {
            return date.Date.AddHours(hour).AddMinutes(minutes);
        }

        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWeekDay(this DateTime date)
        {
            return !date.IsWeekend();
        }
    }
}