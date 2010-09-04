using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Extensions;
using Agenda.ViewModels;

namespace Agenda.Services
{
    public class LoggingAgendaService : IAgendaService
    {
        private readonly IAgendaService agendaService;

        public LoggingAgendaService()
        {
            agendaService = new AgendaService();
        }

        public Dag GetContentFor(DateTime date)
        {
            Output.Write(string.Format("{0}.GetContentFor({1})", GetType().Name, date));
            return agendaService.GetContentFor(date);
        }

        public void Save(Dag dag)
        {
            var courseDescriptions = string.Join(", ", dag.Courses.ConvertAll(c => c.ToString()).ToArray());
            Output.Write(string.Format("{0}.Save([{1}], {2})", GetType().Name, courseDescriptions, dag.Date));
            agendaService.Save(dag);
        }
    }
}