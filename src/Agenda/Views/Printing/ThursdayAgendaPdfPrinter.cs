﻿namespace Agendas.Views.Printing
{
    internal class ThursdayAgendaPdfPrinter : AgendaPdfPrinter
    {
        public ThursdayAgendaPdfPrinter() : base(new ThursdayAgendaPrinterStrategy())
        {
        }

        protected override string GetTemplate()
        {
            return @"Templates\rechts.gif";
        }
    }
}