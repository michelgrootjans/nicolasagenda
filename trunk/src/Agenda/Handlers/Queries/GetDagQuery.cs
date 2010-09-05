using System;
using Agendas.Entities;
using Agendas.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace Agendas.Handlers.Queries
{
    public class GetDagQuery : IQuery<IDag>
    {
        private readonly DateTime dateTime;

        public GetDagQuery(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public IQueryResult<IDag> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<IDag>()
                .Add(Restrictions.Eq("Date", dateTime.Date));
            return new CriteriaResult<IDag>(criteria);
        }
    }
}