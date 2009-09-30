using System;
using Agenda.Presentation;

namespace Agenda.Views
{
    public interface IWindowManager
    {
        IView GetViewAt(DateTime dateTime);
    }

    public class WindowManager : IWindowManager
    {
        private readonly IAgendaPresenter agendaPresenter;

        public WindowManager(IAgendaPresenter agendaPresenter)
        {
            this.agendaPresenter = agendaPresenter;
        }

        public IView GetViewAt(DateTime date)
        {
            return agendaPresenter.GetViewAt(date);
        }
    }
}