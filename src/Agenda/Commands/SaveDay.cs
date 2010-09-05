using System;
using Agendas.Infrastructure;

namespace Agendas.Commands
{
    public class SaveDay : ICommand
    {
        public DateTime Date { get; private set; }

        public SaveDay(DateTime date)
        {
            Date = date;
        }
    }
}