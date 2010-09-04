using System;
using Agenda.Service;

namespace Agenda.Presentation
{
    public interface IAgendaPresenter
    {
        IView GetViewAt(DateTime date);
    }

    public class AgendaPresenter : IAgendaPresenter
    {
        private readonly IPresenterFactory presenterFactory;
        private readonly IScheduleService scheduleService;
        private readonly IAgendaService agendaService;

        public AgendaPresenter(IPresenterFactory presenterFactory, IScheduleService scheduleService, IAgendaService agendaService)
        {
            this.presenterFactory = presenterFactory;
            this.agendaService = agendaService;
            this.scheduleService = scheduleService;
        }

        public IView GetViewAt(DateTime date)
        {
            if (scheduleService.SchoolIsOngoingOn(date))
                return presenterFactory.CreateSchoolPresenter(agendaService, date).View;
            return presenterFactory.CreateHomePresenter(date).View;
        }
    }
}