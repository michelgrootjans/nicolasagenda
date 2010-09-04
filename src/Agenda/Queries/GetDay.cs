using System;
using Agendas.Infrastructure;

namespace Agendas.Queries
{
    public class GetDay : IQuery<GetDayResult>
    {
        public GetDay(DateTime dateTime)
        {
            Date = dateTime.Date;
        }

        public DateTime Date { get; private set; }
    }

    public class GetDayResult : IEvent
    {
    }
}