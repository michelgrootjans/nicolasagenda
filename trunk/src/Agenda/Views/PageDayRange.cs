using System;
using System.Collections;
using System.Collections.Generic;

namespace Agendas.Views
{
    internal interface IPageRange : IEnumerable<DateTime>
    {
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }

    internal class PageDayRange : IPageRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public PageDayRange(DateTime date)
        {
            StartDate = FirstDayOf(date);
            EndDate = LastDayFrom(StartDate);
        }
        private static DateTime FirstDayOf(DateTime dateTime)
        {
            var date = dateTime;
            while (IsValidStartDate(date) == false)
                date = date.AddDays(-1);
            return date;
        }

        private static DateTime LastDayFrom(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Monday)
                return date.AddDays(2);
            return date.AddDays(1);
        }

        private static bool IsValidStartDate(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            return dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Thursday;
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            var currentDate = StartDate;
            while (currentDate <= EndDate)
            {
                yield return currentDate;
                currentDate = currentDate.AddDays(1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}