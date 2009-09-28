using System;
using Agenda.Service;
using Agenda.Extensions;

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
            var now = 30.September(2009).At(9, 00);
            if (scheduleService.SchoolIsOngoingOn(now))
                return new SchoolView(scheduleService, now);
            return new HomeView();
        }
    }
}