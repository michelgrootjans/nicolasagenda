using System;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;

namespace Agendas.Views
{
    internal static class PrinterFactory
    {
        public static IPagePrinter CreatePrinterFor(IPageRange range)
        {
            if (range.Any(p => p.Date.DayOfWeek == DayOfWeek.Monday))
                return new MondayAgendaPdfPrinter();
            return new ThursdayAgendaPdfPrinter();
        }
    }

    internal interface IPagePrinter
    {
        void Print(IEnumerable<IDag> dagen);
    }
}