using System.Collections.Generic;
using Agendas.Entities;
using PdfSharp.Pdf;

namespace Agendas.Views.Printing
{
    internal interface IPagePrinter
    {
        string Print(IEnumerable<IDag> dagen, PdfDocument pdfDocument);
    }
}