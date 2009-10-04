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
        private readonly IScheduleService scheduleService;
        private readonly IAgendaService agendaService;
        private readonly DateTime date;

        public SchoolAgendaPresenter(ISchoolAgendaView schoolAgendaView, IScheduleService scheduleService, IAgendaService agendaService, DateTime date)
        {
            view = schoolAgendaView;
            this.agendaService = agendaService;
            this.date = date;
            this.scheduleService = scheduleService;
            view.SaveChanges += SaveChanges;
            InitializeView();
        }

        private void InitializeView()
        {
            var daysContent = agendaService.GetContentFor(date);
            for (var hour = 0; hour < 7; hour++)
            {
                var courseName = scheduleService.CourseAt(date, hour);
                if (courseName.IsNotNullOrEmpty())
                {
                    var courseControl = view.Courses[hour];
                    var content = daysContent[hour];
                    courseControl.Uur = content.Uur;
                    courseControl.Vak = content.Vak ?? courseName;
                    courseControl.Inhoud = content.Inhoud;
                }
            }
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            agendaService.Save(view.Courses, date);
        }

        public IView View
        {
            get { return view; }
        }
    }
}