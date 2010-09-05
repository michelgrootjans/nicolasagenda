using System;
using Agendas.Infrastructure;

namespace Agendas.Queries
{
    public class GetDayRequest : IRequest<GetDayResponse>
    {
        public GetDayRequest(DateTime dateTime)
        {
            Date = dateTime.Date;
        }

        public DateTime Date { get; private set; }
    }

    public class GetDayResponse : IEvent
    {
        public DateTime Date { get; private set; }
    }
}