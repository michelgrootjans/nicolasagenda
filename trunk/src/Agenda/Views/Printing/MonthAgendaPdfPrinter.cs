using System.Collections.Generic;
using Agendas.Entities;
using PdfSharp.Pdf;

namespace Agendas.Views.Printing
{
    internal class MonthAgendaPdfPrinter : IPagePrinter
    {
        public string Print(IEnumerable<IDag> dagen, PdfDocument pdfDocument)
        {
            //var pageFactory = new AgendaPageFactory();
            //foreach (var page in pageFactory)
            //{
                
            //}
            return null;
        }
    }

    internal class AgendaPageFactory
    {
    }
}