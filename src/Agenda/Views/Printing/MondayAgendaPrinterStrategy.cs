using Agendas.Entities;

namespace Agendas.Views.Printing
{
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
}