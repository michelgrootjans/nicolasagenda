using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Agendas.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

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

    internal class MondayAgendaPdfPrinter : IPagePrinter
    {
        public void Print(IEnumerable<IDag> dagen)
        {
            var pdfDocument = new PdfDocument();
            var page = pdfDocument.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var image = XImage.FromFile(@"Templates\Agenda pag links blank.jpg");
            graphics.DrawImage(image, 0, 0);
            pdfDocument.Save("Agenda.pdf");
            Process.Start("Agenda.pdf");
        }
    }

    internal class ThursdayAgendaPdfPrinter : IPagePrinter
    {
        public void Print(IEnumerable<IDag> dagen)
        {

        }
    }
}