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
        private const string fileName = "Agenda.pdf";

        public void Print(IEnumerable<IDag> dagen)
        {
            var pdfDocument = new PdfDocument();
            var page = pdfDocument.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            DrawPage(graphics);
            //DrawGrid(graphics, page);

            VulDagenIn(graphics, dagen);

            SaveAndShow(pdfDocument);
        }

        private void VulDagenIn(XGraphics graphics, IEnumerable<IDag> dagen)
        {
            var maandag = dagen.Where(d => d.Date.DayOfWeek == DayOfWeek.Monday).First();
            var dinsdag = dagen.Where(d => d.Date.DayOfWeek == DayOfWeek.Tuesday).First();
            var woensdag = dagen.Where(d => d.Date.DayOfWeek == DayOfWeek.Wednesday).First();
            var dateFont = new XFont("Verdana", 12, XFontStyle.Bold);
            var dateBrush = XBrushes.White;
            var vakFont = new XFont("Verdana", 12, XFontStyle.Bold);
            var vakBrush = XBrushes.Blue;
            var lesFont = new XFont("Verdana", 8, XFontStyle.Bold);
            var lesBrush = XBrushes.Blue;

            graphics.DrawString(maandag.Date.ToLongDateString(), dateFont, dateBrush, 225, 30);
            var position = 0;
            foreach (var lesUur in maandag.Vakken.OrderBy(v => v.Uur))
            {
                graphics.DrawString(lesUur.Naam, vakFont, vakBrush, 230, 55 + 33*position);
                graphics.DrawString(lesUur.Inhoud, lesFont, lesBrush, 280, 48 + 33.5*position);
                position++;
            }

            graphics.DrawString(dinsdag.Date.ToLongDateString(), dateFont, dateBrush, 225, 318);
            position = 0;
            foreach (var lesUur in dinsdag.Vakken.OrderBy(v => v.Uur))
            {
                graphics.DrawString(lesUur.Naam, vakFont, vakBrush, 230, 343 + 33 * position);
                graphics.DrawString(lesUur.Inhoud, lesFont, lesBrush, 280, 336 + 33.5 * position);
                position++;
            }

            graphics.DrawString(dinsdag.Date.ToLongDateString(), dateFont, dateBrush, 225, 607);
            position = 0;
            foreach (var lesUur in woensdag.Vakken.OrderBy(v => v.Uur))
            {
                graphics.DrawString(lesUur.Naam, vakFont, vakBrush, 230, 632 + 33 * position);
                graphics.DrawString(lesUur.Inhoud, lesFont, lesBrush, 280, 625 + 33.5 * position);
                position++;
            }
        }

        private static void SaveAndShow(PdfDocument pdfDocument)
        {
            pdfDocument.Save(fileName);
            Process.Start(fileName);
        }

        private void DrawPage(XGraphics graphics)
        {
            var image = XImage.FromFile(@"Templates\Agenda pag links blank.jpg");
            graphics.DrawImage(image, 0, 0);
        }

        private void DrawGrid(XGraphics graphics, PdfPage page)
        {
            var thickPen = new XPen(XColors.LightGray, 1);
            var lightPen = new XPen(XColors.LightGray, .5);
            var font = new XFont("Verdana", 8);
            var brush = XBrushes.LightGray;
            for (var x = 0; x < page.Width; x += 10)
            {
                if (x%50 == 0)
                {
                    graphics.DrawString(x.ToString(), font, brush, x, 50);
                    graphics.DrawLine(thickPen, x, 0, x, page.Height);
                }
                else
                    graphics.DrawLine(lightPen, x, 0, x, page.Height);
            }
            for (var y = 0; y < page.Height; y += 10)
            {
                if (y%50 == 0)
                {
                    graphics.DrawString(y.ToString(), font, brush, 50, y);
                    graphics.DrawLine(thickPen, 0, y, page.Width, y);
                }
                else
                    graphics.DrawLine(lightPen, 0, y, page.Width, y);
            }
        }
    }

    internal class ThursdayAgendaPdfPrinter : IPagePrinter
    {
        public void Print(IEnumerable<IDag> dagen)
        {
        }
    }
}