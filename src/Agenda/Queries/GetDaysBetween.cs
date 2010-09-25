using System;
using Agendas.Entities;
using Agendas.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace Agendas.Queries
{
    internal class GetDaysBetween : IQuery<Dag>
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public GetDaysBetween(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public IQueryResult<Dag> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<Dag>()
                .Add(Restrictions.Ge("Date", StartDate))
                .Add(Restrictions.Le("Date", EndDate))
                .AddOrder(Order.Asc("Date"));

            return new CriteriaResult<Dag>(criteria);
        }
    }
}