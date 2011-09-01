using Agendas.Entities;

namespace Agendas.Views.Printing
{
    internal class MondayAgendaPrinterStrategy : AgendaPrinterStrategy
    {
        private const int DagOffset = 85;

        protected override int GetDagOffset(IDag dag)
        {
            return dag.DayNumber*DistanceBetweenDays;
        }

        protected override double XOffset
        {
            get { return DagOffset; }
        }
    }
}