using System;
using System.Collections.Generic;
using Agendas.Entities;

namespace Agendas.Views
{
    internal static class DagFactory
    {
        public static IDag CreateDag(DateTime dateTime)
        {
            var dag = new Dag(dateTime);
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    PopulateMaandag(dag);
                    break;
                case DayOfWeek.Tuesday:
                    PopulateDinsdag(dag);
                    break;
                case DayOfWeek.Wednesday:
                    PopulateWoensdag(dag);
                    break;
                case DayOfWeek.Thursday:
                    PopulateDonderdag(dag);
                    break;
                case DayOfWeek.Friday:
                    PopulateVrijdag(dag);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return dag;
        }

        private static void PopulateMaandag(Dag dag)
        {
            dag.AddVak(1, "WIS", "");
            dag.AddVak(2, "GES", "");
            dag.AddVak(3, "FRA", "");
            dag.AddVak(4, "NED", "");
            dag.AddVak(5, "ENG", "");
            dag.AddVak(6, "LO", "");
            dag.AddVak(7, "WWK", "");
        }

        private static void PopulateDinsdag(Dag dag)
        {
            dag.AddVak(1, "WIS", "");
            dag.AddVak(2, "GOD", "");
            dag.AddVak(3, "FRA", "");
            dag.AddVak(4, "NED", "");
            dag.AddVak(5, "ENG", "");
            dag.AddVak(6, "SEI", "");
            dag.AddVak(7, "MO", "");
        }

        private static void PopulateWoensdag(Dag dag)
        {
            dag.AddVak(1, "AAR", "");
            dag.AddVak(2, "FRA", "");
            dag.AddVak(3, "GES", "");
            dag.AddVak(4, "WIS", "");
        }

        private static void PopulateDonderdag(Dag dag)
        {
            dag.AddVak(1, "GOD", "");
            dag.AddVak(2, "SOAC", "");
            dag.AddVak(3, "WIS", "");
            dag.AddVak(4, "BIO", "");
            dag.AddVak(5, "WWK", "");
            dag.AddVak(6, "WWK", "");
            dag.AddVak(7, "SEI", "");
        }

        private static void PopulateVrijdag(Dag dag)
        {
            dag.AddVak(1, "LO", "");
            dag.AddVak(2, "WIS", "");
            dag.AddVak(3, "TO", "");
            dag.AddVak(4, "TO", "");
            dag.AddVak(5, "NED", "");
            dag.AddVak(6, "NED", "");
            dag.AddVak(7, "FRA", "");
        }

        public static void Complete(PageRange pageRange, IEnumerable<Dag> dagen)
        {
            throw new NotImplementedException();
        }
    }
}