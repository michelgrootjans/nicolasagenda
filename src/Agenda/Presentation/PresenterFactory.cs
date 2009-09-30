using System;
using Agenda.Service;
using Agenda.Views;

namespace Agenda.Presentation
{
    public interface IPresenterFactory
    {
        IPresenter CreateSchoolPresenter(IAgendaService agendaService, DateTime date);
        IPresenter CreateHomePresenter(DateTime date);
    }

    public class PresenterFactory : IPresenterFactory
    {
        private readonly ScheduleService scheduleService;

        public PresenterFactory(ScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        public IPresenter CreateSchoolPresenter(IAgendaService agendaService, DateTime date)
        {
            return new SchoolAgendaPresenter(new SchoolView(), scheduleService, agendaService, date);
        }

        public IPresenter CreateHomePresenter(DateTime date)
        {
            return new HomeAgendaPresenter(new HomeView(), scheduleService, date);
        }
    }
}