using System;

namespace Agenda.ViewModels
{
    public class Opgave
    {
        public DateTime DatumOpgave { get; set; }
        public DateTime Deadline { get; set; }
        public string Vak { get; set; }
        public string Inhoud { get; set; }
    }
}