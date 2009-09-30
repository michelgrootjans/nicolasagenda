using System;
using Agenda.Extensions;
using Agenda.Service;
using Agenda.Views;

namespace Agenda.Presentation
{
    public interface ISchoolAgendaPresenter : IPresenter
    {
    }

    internal class SchoolAgendaPresenter : ISchoolAgendaPresenter
    {
        private readonly ISchoolAgendaView view;
        private readonly IScheduleService service;
        private readonly IAgendaService agendaService;
        private readonly DateTime date;

        public SchoolAgendaPresenter(ISchoolAgendaView schoolAgendaView, IScheduleService scheduleService, IAgendaService agendaService, DateTime date)
        {
            view = schoolAgendaView;
            this.agendaService = agendaService;
            this.date = date;
            service = scheduleService;
            InitializeView();
        }

        private void InitializeView()
        {
            var daysContent = agendaService.GetContentFor(date);
            for (var hour = 1; hour <= 7; hour++)
            {
                var courseName = service.CourseAt(date, hour);
                if (courseName.IsNotNullOrEmty())
                {
                    var courseControl = view.GetCourse(hour);
                    courseControl.CourseName = courseName;
                    courseControl.CourseContent = daysContent[hour].CourseContent;
                }
            }
        }

        public IView View
        {
            get { return view; }
        }
    }
}