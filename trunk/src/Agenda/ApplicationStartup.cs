using Agenda.Presentation;
using Agenda.Service;

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