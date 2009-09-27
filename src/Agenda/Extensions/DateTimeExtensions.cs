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
    }
}