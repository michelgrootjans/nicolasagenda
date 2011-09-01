using System;
using System.Collections;
using System.Collections.Generic;
using Agendas.Extensions;

namespace Agendas.Views
{
    internal class MonthDayRange : IPageRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public MonthDayRange(DateTime date)
        {
            setDate(date, 7.Februari(2011), 4.March(2011));
            setDate(date, 14.March(2011), 1.April(2011));
            setDate(date, 4.April(2011), 29.April(2011));
            setDate(date, 2.May(2011), 3.June(2011));
            setDate(date, 6.June(2011), 3.July(2011));
            setDate(date, 1.September(2011), 30.September(2011));
            setDate(date, 3.October(2011), 28.October(2011));
            setDate(date, 7.November(2011), 2.December(2011));
            setDate(date, 5.December(2011), 23.December(2011));
        }

        private void setDate(DateTime date, DateTime startDate, DateTime endDate)
        {
            if (!date.IsBetween(startDate, endDate)) return;

            StartDate = startDate;
            EndDate = endDate;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
    }
}