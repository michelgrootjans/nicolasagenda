using System;

namespace Agendas.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime At(this DateTime date, int hour)
        {
            return date.Date.AddHours(hour);
        }
    }
}