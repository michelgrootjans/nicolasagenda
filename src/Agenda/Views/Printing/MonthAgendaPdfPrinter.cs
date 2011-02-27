using System;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;
using PdfSharp.Pdf;

namespace Agendas.Views.Printing
{
    internal class MonthAgendaPdfPrinter : IPagePrinter
    {
        public string Print(IEnumerable<IDag> dagen, PdfDocument pdfDocument)
        {
            var chunker = new WeekChunker(dagen);
            foreach (var chunk in chunker)
            {
                if (chunk.DayOfWeek == DayOfWeek.Monday)
                    new MondayAgendaPdfPrinter().Print(chunk.Days, pdfDocument);
                if (chunk.DayOfWeek == DayOfWeek.Thursday)
                    new ThursdayAgendaPdfPrinter().Print(chunk.Days, pdfDocument);
            }

            return dagen.ToList()[6].Date.ToString("MMMM") + ".pdf";
        }
    }
}