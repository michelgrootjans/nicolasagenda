using System;
using Agendas.Entities;
using Agendas.Infrastructure;
using NHibernate;

namespace Agendas.Queries
{
    internal class GetDueTaken : IQuery<Taak>
    {
        public IQueryResult<Taak> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<Taak>();
            return new CriteriaResult<Taak>(criteria);
        }
    }
}