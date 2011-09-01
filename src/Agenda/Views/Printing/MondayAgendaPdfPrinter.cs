namespace Agendas.Views.Printing
{
    internal class MondayAgendaPdfPrinter : AgendaPdfPrinter
    {
        public MondayAgendaPdfPrinter() : base(new MondayAgendaPrinterStrategy())
        {
        }

        protected override string GetTemplate()
        {
            return @"Templates\links.gif";
        }
    }
}