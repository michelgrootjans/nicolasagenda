using System;
using Agenda.Services;

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
            if (scheduleService.LessonIsOngoing)
                return new SchoolView();
            return new HomeView();
        }
    }
}