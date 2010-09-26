using System;
using System.Collections.Generic;
using Agendas.Entities;
using Agendas.Events;
using Agendas.Infrastructure;
using Agendas.Queries;

namespace Agendas.Views
{
    public class DagPresenter : Presenter, IPresenter<DayView>, IListenTo<PrintCurrentViewEvent>
    {
        private readonly IDagView view;

        public DagPresenter(IDagView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            view.Dag = GetOrCreateDag(view.Date);
        }

        private IDag GetOrCreateDag(DateTime dateTime)
        {
            var dag = Session.Query(new GetDayQuery(dateTime)).UniqueResult()
                      ?? DagFactory.CreateDag(dateTime);
            return dag;
        }

        protected override void SaveIfChanged()
        {
            if (view.HasChanged)
                using (var transaction = Session.BeginTransaction())
                {
                    Session.SaveOrUpdate(view.Dag);
                    transaction.Commit();
                }
        }

        public void HandleEvent(PrintCurrentViewEvent domainEvent)
        {
            if (view.HasFocus)
                ShowCurrentPage(view.Date);
        }

        private void ShowCurrentPage(DateTime date)
        {
            var pageRange = new PageDayRange(date);
            var dagen = Session.Query(new GetDaysBetween(pageRange.StartDate, pageRange.EndDate)).List();
            var printer = PrinterFactory.CreatePrinterFor(pageRange);
            printer.Print(DagFactory.Complete(pageRange, dagen));
        }
    }
}