using Agendas.Entities;
using PdfSharp.Drawing;

namespace Agendas.Views.Printing
{
    internal interface IPagePrinterStrategy
    {
        void Print(IDag dag, XGraphics graphics);
    }
}