using System;
using Agendas.Entities;
using Agendas.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace Agendas.Views
{
    public class GetDayQuery : IQuery<IDag>
    {
        private DateTime day;

        public GetDayQuery(DateTime day)
        {
            this.day = day.Date;
        }

        public IQueryResult<IDag> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<IDag>()
                .Add(Restrictions.Eq("Date", day));
            return new CriteriaResult<IDag>(criteria);
        }
    }
}