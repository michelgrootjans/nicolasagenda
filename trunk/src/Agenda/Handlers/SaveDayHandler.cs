using System;
using Agendas.Commands;
using Agendas.Entities;
using Agendas.Handlers.Queries;
using Agendas.Infrastructure;

namespace Agendas.Handlers
{
    public class SaveDayHandler : ICommandHandler<SaveDay>
    {
        public void Execute(SaveDay command)
        {
            using (var session = NHibernateProvider.CreateSession())
            using (var transaction = session.BeginTransaction())
            {
                var day = session.Query(new GetDagQuery(command.Date)).UniqueResult();
                if(day == null)
                    session.Save(new Day(command.Date));
                transaction.Commit();
            }
        }
    }
}