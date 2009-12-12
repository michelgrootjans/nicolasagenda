using System;
using Agenda.Extensions;
using Agenda.Services;
using Agenda.ViewModels;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;

namespace Agenda.Presenters
{
    public interface IDagPresenter : IPresenter
    {
    }

    [PerRequest(typeof(IDagPresenter))]
    public class DagPresenter : Presenter, IDagPresenter
    {
        private readonly IAgendaService agendaService;
        public Dag Dag { get; private set; }

        public DagPresenter()
        {
            agendaService = new LoggingAgendaService();
        }

        public override void Activate()
        {
            UpdateDag(MostRecentSchoolday());
        }

        public void PreviousDay()
        {
            UpdateDag(NextSchoolDay(-1));
        }

        public void NextDay()
        {
            UpdateDag(NextSchoolDay(1));
        }

        private void UpdateDag(DateTime dateTime)
        {
            if (Dag != null)
                agendaService.Save(Dag);
            Dag = agendaService.GetContentFor(dateTime);
            RaisePropertyChangedEventImmediately("Dag");
        }


        private DateTime MostRecentSchoolday()
        {
            var schoolday = DateTime.Now;
            while (schoolday.IsWeekend())
                schoolday = schoolday.AddDays(-1);
            return schoolday;
        }

        private DateTime NextSchoolDay(int direction)
        {
            var nextSchoolDay = Dag.Date.AddDays(direction);
            while (nextSchoolDay.IsWeekend())
                nextSchoolDay = nextSchoolDay.AddDays(direction);
            return nextSchoolDay;
        }

        public override void Deactivate()
        {
            agendaService.Save(Dag);
        }
    }
}