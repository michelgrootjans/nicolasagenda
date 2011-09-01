using System.Linq;
using Agendas.Entities;
using PdfSharp.Drawing;

namespace Agendas.Views.Printing
{
    internal abstract class AgendaPrinterStrategy : IPagePrinterStrategy
    {
        protected const int DistanceBetweenDays = 280;
        private readonly XFont dateFont;
        private readonly XSolidBrush dateBrush;
        private readonly XFont vakFont;
        private readonly XSolidBrush vakBrush;
        private readonly XFont lesFont;
        private readonly XSolidBrush lesBrush;

        protected AgendaPrinterStrategy()
        {
            dateFont = new XFont("Verdana", 12, XFontStyle.Bold);
            dateBrush = XBrushes.Black;
            vakFont = new XFont("Helvetica", 12, XFontStyle.Bold);
            vakBrush = XBrushes.Black;
            lesFont = new XFont("Verdana", 8, XFontStyle.Bold);
            lesBrush = XBrushes.Blue;
        }

        public void Print(IDag dag, XGraphics graphics)
        {
            var dagTitel = dag.Date.ToString("d MMMM");
            var dagOffset = GetDagOffset(dag);
            DrawDate(graphics, dagTitel, 32 + dagOffset);
            foreach (var lesUur in dag.Vakken.OrderBy(v => v.Uur))
            {
                var vakOffset = dagOffset + 31*(lesUur.Uur - 1);
                DrawVak(graphics, lesUur, 58 + vakOffset);
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
}