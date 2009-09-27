using System;
using Agenda.Service;

namespace Agenda.Presentation
{
    public interface IWindowManager
    {
        IView GetViewAt(DateTime time);
    }

    public class WindowManager : IWindowManager
    {
        private readonly IScheduleService scheduleService;

        public WindowManager(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        public IView GetViewAt(DateTime date)
        {
            if (scheduleService.SchoolIsOngoingOn(DateTime.Now))
                return new SchoolView();
            return new HomeView();
        }
    }
}