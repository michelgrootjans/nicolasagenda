using Agendas.Entities;
using Agendas.Infrastructure;
using Agendas.Queries;
using NHibernate.Criterion;

namespace Agendas.Handlers
{
    public class GetDayHandler : IQueryHandler<GetDay, GetDayResult>
    {
        public GetDayResult Handle(GetDay query)
        {
            var session = NHibernateSessionProvider.GetSession();
            var dag = session.CreateCriteria<IDag>()
                .Add(Restrictions.Eq("Date", query.Date))
                .UniqueResult();
            return Map.This(dag).ToA<GetDayResult>();
        }
    }
}