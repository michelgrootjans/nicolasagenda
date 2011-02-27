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
            if(date.IsBetween(7.Februari(2011), 4.March(2011)))
            {
                StartDate = 7.Februari(2011);
                EndDate = 4.March(2011);
            }
            if(date.IsBetween(7.March(2011), 1.April(2011)))
            {
                StartDate = 7.March(2011);
                EndDate = 1.April(2011);
            }
            if(date.IsBetween(4.April(2011), 29.April(2011)))
            {
                StartDate = 4.April(2011);
                EndDate = 29.April(2011);
            }
            if (date.IsBetween(2.May(2011), 3.June(2011)))
            {
                StartDate = 2.May(2011);
                EndDate = 3.June(2011);
            }
            if (date.IsBetween(6.June(2011), 3.July(2011)))
            {
                StartDate = 6.June(2011);
                EndDate = 3.July(2011);
            }
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