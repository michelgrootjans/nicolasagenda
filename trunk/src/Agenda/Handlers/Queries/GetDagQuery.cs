using System;
using Agendas.Entities;
using Agendas.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace Agendas.Handlers.Queries
{
    public class GetDagQuery : IQuery<IDay>
    {
        private readonly DateTime dateTime;

        public GetDagQuery(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public IQueryResult<IDay> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<IDay>()
                .Add(Restrictions.Eq("Date", dateTime.Date));
            return new CriteriaResult<IDay>(criteria);
        }
    }
}