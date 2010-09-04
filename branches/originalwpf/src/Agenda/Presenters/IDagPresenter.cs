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
        Dag Dag { get;}
        void GoToNextDay();
        void GoToPreviousDay();
    }

    [PerRequest(typeof (IDagPresenter))]
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

        public void GoToPreviousDay()
        {
            UpdateDag(Dag.PreviousSchoolDay);
        }

        public void GoToNextDay()
        {
            UpdateDag(Dag.NextSchoolDay);
        }

        private void UpdateDag(DateTime dateTime)
        {
            if (Dag != null)
                agendaService.Save(Dag);
            Dag = agendaService.GetContentFor(dateTime);
            RaisePropertyChangedEventImmediately("Dag");
        }


        public DateTime MostRecentSchoolday()
        {
            var schoolday = DateTime.Now;
            while (schoolday.IsWeekend())
                schoolday = schoolday.AddDays(-1);
            return schoolday;
        }

        public override void Deactivate()
        {
            agendaService.Save(Dag);
        }
    }
}