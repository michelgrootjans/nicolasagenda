using Agenda.Presentation;
using Agenda.Service;

namespace Agenda
{
    public class ApplicationStartup
    {
        public static IWindowManager Run()
        {
            var scheduleService = new ScheduleService();
            var presenterFactory = new PresenterFactory(scheduleService);
            var agendaService = new AgendaService();
            var schoolPresenter = new AgendaPresenter(presenterFactory, scheduleService, agendaService);
            
            return new WindowManager(schoolPresenter);
        }
    }
}