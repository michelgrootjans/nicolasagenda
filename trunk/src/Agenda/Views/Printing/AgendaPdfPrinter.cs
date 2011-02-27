using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Agendas.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Agendas.Views.Printing
{
    internal abstract class AgendaPdfPrinter : IPagePrinter
    {
        private readonly IPagePrinterStrategy strategy;

        protected AgendaPdfPrinter(IPagePrinterStrategy strategy)
        {
            this.strategy = strategy;
        }

        protected abstract string GetTemplate();

        public string Print(IEnumerable<IDag> dagen, PdfDocument pdfDocument)
        {
            var page = pdfDocument.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            DrawPage(graphics, page);
            //DrawGrid(graphics, page);
            VulDagenIn(graphics, dagen);

            string fileName = dagen.First().Date.ToLongDateString() + ".pdf";
            pdfDocument.Save(fileName);
            return fileName;
        }

        private void VulDagenIn(XGraphics graphics, IEnumerable<IDag> dagen)
        {
            foreach (var dag in dagen)
                strategy.Print(dag, graphics);
        }

        private void DrawPage(XGraphics graphics, PdfPage page)
        {
            var image = XImage.FromFile(GetTemplate());
            graphics.DrawImage(image, 0, 0, page.Width, page.Height);
        }

        private static void DrawGrid(XGraphics graphics, PdfPage page)
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
}