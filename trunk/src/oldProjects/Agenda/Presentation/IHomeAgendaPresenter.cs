using System;
using Agenda.Service;
using Agenda.Views;

namespace Agenda.Presentation
{
    public interface IHomeAgendaPresenter : IPresenter
    {
        
    }

    class HomeAgendaPresenter : IHomeAgendaPresenter
    {
        public HomeAgendaPresenter(HomeView view, IScheduleService scheduleService, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IView View
        {
            get { throw new NotImplementedException(); }
        }
    }
}