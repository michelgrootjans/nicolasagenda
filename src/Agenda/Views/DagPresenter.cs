using System;
using System.Diagnostics;
using Agendas.Entities;
using Agendas.Events;
using Agendas.Extensions;
using Agendas.Infrastructure;
using Agendas.Queries;
using Agendas.Views.Printing;
using PdfSharp.Pdf;

namespace Agendas.Views
{
    public class DagPresenter : Presenter, IDagViewPresenter, IListenTo<PrintCurrentViewEvent>,
                                IListenTo<PrintCurrentMonthEvent>
    {
        private readonly IDagView view;

        public DagPresenter(IDagView view)
        {
            this.view = view;
            view.Date = MoveToNextWorkday(view.Date);
        }

        public void Initialize()
        {
            view.Dag = GetOrCreateDag(view.Date);
        }

        private IDag GetOrCreateDag(DateTime dateTime)
        {
            using (var session = NHibernateProvider.CreateSession())
            {
                return session.Query(new GetDayQuery(dateTime)).UniqueResult()
                       ?? DagFactory.CreateDag(dateTime);
            }
        }

        protected void SaveIfChanged()
        {
            if (view.HasChanged == false) return;

            using (var session = NHibernateProvider.CreateSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(view.Dag);
                transaction.Commit();
            }
        }

        public void HandleEvent(PrintCurrentViewEvent domainEvent)
        {
            if (view.HasFocus)
                ShowCurrentPage(view.Date);
        }

        public void HandleEvent(PrintCurrentMonthEvent domainEvent)
        {
            if (view.HasFocus)
                ShowCurrentMonth(view.Date);
        }

        private void ShowCurrentMonth(DateTime date)
        {
            using (var session = NHibernateProvider.CreateSession())
            {
                IPageRange pageRange = new MonthDayRange(date);
                var dagen = session.Query(new GetDaysBetween(pageRange.StartDate, pageRange.EndDate)).List();
                var printer = PrinterFactory.CreatePrinterFor(pageRange);
                var fileName = printer.Print(DagFactory.Complete(pageRange, dagen), new PdfDocument());
                //Process.Start(fileName);
            }
        }

        private void ShowCurrentPage(DateTime date)
        {
            using (var session = NHibernateProvider.CreateSession())
            {
                IPageRange pageRange = new PageDayRange(date);
                var dagen = session.Query(new GetDaysBetween(pageRange.StartDate, pageRange.EndDate)).List();
                var printer = PrinterFactory.CreatePrinterFor(pageRange);
                var fileName = printer.Print(DagFactory.Complete(pageRange, dagen), new PdfDocument());
                Process.Start(fileName);
            }
        }

        public override void Dispose()
        {
            SaveIfChanged();
            base.Dispose();
        }

        private DateTime MoveToNextWorkday(DateTime date)
        {
            while (date.IsWeekendDay())
                date = date.AddDays(1);
            return date;
        }
    }

    public interface IDagViewPresenter
    {
        void Initialize();
    }
}