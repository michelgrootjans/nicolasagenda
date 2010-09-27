using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Agendas.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Agendas.Views
{
    internal abstract class AgendaPdfPrinter : IPagePrinter
    {
        private readonly IPagePrinterStrategy strategy;

        protected AgendaPdfPrinter(IPagePrinterStrategy strategy)
        {
            this.strategy = strategy;
        }

        protected abstract string GetTemplate();

        public void Print(IEnumerable<IDag> dagen)
        {
            var pdfDocument = new PdfDocument();
            var page = pdfDocument.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            DrawPage(graphics);
            //DrawGrid(graphics, page);

            VulDagenIn(graphics, dagen);

            SaveAndShow(pdfDocument, dagen.First().Date.ToLongDateString() + ".pdf");
        }

        private void VulDagenIn(XGraphics graphics, IEnumerable<IDag> dagen)
        {
            foreach (var dag in dagen)
                strategy.Print(dag, graphics);
        }

        private static void SaveAndShow(PdfDocument pdfDocument, string fileName)
        {
            pdfDocument.Save(fileName);
            Process.Start(fileName);
        }

        private void DrawPage(XGraphics graphics)
        {
            var image = XImage.FromFile(GetTemplate());
            graphics.DrawImage(image, 0, 0);
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

    internal interface IPagePrinterStrategy
    {
        void Print(IDag dag, XGraphics graphics);
    }

    internal abstract class AgendaPrinterStrategy : IPagePrinterStrategy
    {
        protected const int DistanceBetweenDays = 289;
        private readonly XFont dateFont;
        private readonly XSolidBrush dateBrush;
        private readonly XFont vakFont;
        private readonly XSolidBrush vakBrush;
        private readonly XFont lesFont;
        private readonly XSolidBrush lesBrush;

        protected AgendaPrinterStrategy()
        {
            dateFont = new XFont("Verdana", 12, XFontStyle.Bold);
            dateBrush = XBrushes.White;
            vakFont = new XFont("Verdana", 12, XFontStyle.Bold);
            vakBrush = XBrushes.Black;
            lesFont = new XFont("Verdana", 8, XFontStyle.Bold);
            lesBrush = XBrushes.Blue;
        }

        public void Print(IDag dag, XGraphics graphics)
        {
            var dagTitel = dag.Date.ToLongDateString();
            var dagOffset = GetDagOffset(dag);
            DrawDate(graphics, dagTitel, 30 + dagOffset);
            foreach (var lesUur in dag.Vakken.OrderBy(v => v.Uur))
            {
                var vakOffset = dagOffset + 33.5*(lesUur.Uur - 1);
                DrawVak(graphics, lesUur, 55 + vakOffset);
                DrawLes(graphics, lesUur, 48 + vakOffset);
            }
        }

        protected abstract int GetDagOffset(IDag dag);

        private void DrawDate(XGraphics graphics, string dagTitel, int yPosition)
        {
            graphics.DrawString(dagTitel, dateFont, dateBrush, 200 + XOffset, yPosition);
        }

        protected abstract double XOffset { get; }

        private void DrawVak(XGraphics graphics, ILesUur lesUur, double vakPositie)
        {
            graphics.DrawString(lesUur.Naam, vakFont, vakBrush, 205 + XOffset, vakPositie);
        }

        private void DrawLes(XGraphics graphics, ILesUur lesUur, double lesPositie)
        {
            graphics.DrawString(lesUur.Inhoud, lesFont, lesBrush, 255 + XOffset, lesPositie);
        }
    }

    internal class MondayAgendaPdfPrinter : AgendaPdfPrinter
    {
        public MondayAgendaPdfPrinter() : base(new MondayAgendaPrinterStrategy())
        {
        }

        protected override string GetTemplate()
        {
            return @"Templates\Agenda pag links blank.jpg";
        }
    }

    internal class ThursdayAgendaPdfPrinter : AgendaPdfPrinter
    {
        public ThursdayAgendaPdfPrinter() : base(new ThursdayAgendaPrinterStrategy())
        {
        }

        protected override string GetTemplate()
        {
            return @"Templates\Agenda pag rechts blank.jpg";
        }
    }

    internal class MondayAgendaPrinterStrategy : AgendaPrinterStrategy
    {
        protected override int GetDagOffset(IDag dag)
        {
            return dag.DayOfWeek*DistanceBetweenDays;
        }

        protected override double XOffset
        {
            get { return 25; }
        }
    }

    internal class ThursdayAgendaPrinterStrategy : AgendaPrinterStrategy
    {
        protected override int GetDagOffset(IDag dag)
        {
            return 5 + (dag.DayOfWeek - 3)*DistanceBetweenDays;
        }

        protected override double XOffset
        {
            get { return 0; }
        }
    }
}