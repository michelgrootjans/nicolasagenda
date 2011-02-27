using Agendas.Entities;

namespace Agendas.Views.Printing
{
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