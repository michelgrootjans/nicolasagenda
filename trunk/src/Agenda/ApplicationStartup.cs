using Agenda.Presentation;
using Agenda.Services;

namespace Agenda
{
    public class ApplicationStartup
    {
        public static IWindowManager Run()
        {
            return new WindowManager(new ScheduleService());
        }
    }
}