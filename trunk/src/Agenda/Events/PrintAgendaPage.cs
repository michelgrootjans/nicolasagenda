using System;

namespace Agendas.Events
{
    internal class PrintAgendaPage
    {
        public DateTime Date { get; private set; }

        public bool IsFirstPartOfWeek
        {
            get { throw new NotImplementedException(); }
        }

        public PrintAgendaPage(DateTime date)
        {
            Date = date;
        }
    }
}