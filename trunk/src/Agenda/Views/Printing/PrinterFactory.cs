using System;
using System.Linq;

namespace Agendas.Views.Printing
{
    internal static class PrinterFactory
    {
        public static IPagePrinter CreatePrinterFor(IPageRange range)
        {
            if (range.Count() > 7)
                return new MonthAgendaPdfPrinter();
            if (range.Any(p => p.Date.DayOfWeek == DayOfWeek.Monday))
                return new MondayAgendaPdfPrinter();
            return new ThursdayAgendaPdfPrinter();
        }
    }
}