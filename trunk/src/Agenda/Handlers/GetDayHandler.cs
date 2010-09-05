using System;
using Agendas.Entities;
using Agendas.Handlers.Queries;
using Agendas.Infrastructure;
using Agendas.Queries;
using NHibernate;

namespace Agendas.Handlers
{
    public class GetDayHandler : IRequestHandler<GetDayRequest, GetDayResponse>
    {
        public GetDayResponse Handle(GetDayRequest request)
        {
            using (var session = NHibernateProvider.CreateSession())
            {
                var day = GetOrCreateDay(session, request.Date);
                return Map.This(day).ToA<GetDayResponse>();
            }
        }

        private IDay GetOrCreateDay(ISession session, DateTime dateTime)
        {
            var day = session
                .Query(new GetDagQuery(dateTime))
                .UniqueResult();
            return day ?? new Day(dateTime);
        }
    }
}