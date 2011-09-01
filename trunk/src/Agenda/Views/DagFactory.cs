using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;

namespace Agendas.Views
{
    internal static class DagFactory
    {
        public static IEnumerable<IDag> Complete(IPageRange dateDayRange, IEnumerable<Dag> dagen)
        {
            foreach (var date in dateDayRange)
            {
                if (dagen.Any(d => d.Date.Equals(date))) 
                    yield return dagen.Where(d => d.Date.Equals(date)).First();
                else if(date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday) 
                    yield return CreateDag(date);
            }
        }

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
                default:
                    PopulateVrijdag(dag);
                    break;
            }
            return dag;
        }

        private static void PopulateMaandag(Dag dag)
        {
            dag.AddVak(1, "GES", "");
            dag.AddVak(2, "NED", "");
            dag.AddVak(3, "AAR", "");
            dag.AddVak(4, "ENG", "");
            dag.AddVak(5, "INF", "");
            dag.AddVak(6, "GOD", "");
            dag.AddVak(7, "BIO", "");
        }

        private static void PopulateDinsdag(Dag dag)
        {
            dag.AddVak(1, "LO", "");
            dag.AddVak(2, "FYS", "");
            dag.AddVak(3, "WIS", "");
            dag.AddVak(4, "WIS", "");
            dag.AddVak(5, "FRA", "");
            dag.AddVak(6, "FRA", "");
            dag.AddVak(7, "NED", "");
        }

        private static void PopulateWoensdag(Dag dag)
        {
            dag.AddVak(1, "NED", "");
            dag.AddVak(2, "ENG", "");
            dag.AddVak(3, "CHEM", "");
            dag.AddVak(4, "FRA", "");
        }

        private static void PopulateDonderdag(Dag dag)
        {
            dag.AddVak(1, "GOD", "");
            dag.AddVak(2, "NED", "");
            dag.AddVak(3, "WIS", "");
            dag.AddVak(4, "FRA", "");
            dag.AddVak(5, "INF", "");
            dag.AddVak(6, "WIS", "");
            dag.AddVak(7, "LO", "");
        }

        private static void PopulateVrijdag(Dag dag)
        {
            dag.AddVak(1, "ENG", "");
            dag.AddVak(2, "BIO", "");
            dag.AddVak(3, "PO", "");
            dag.AddVak(4, "WIS", "");
            dag.AddVak(5, "FYS", "");
            dag.AddVak(6, "GES", "");
            dag.AddVak(7, "CHEM", "");
        }

        public static IEnumerable AlleVakken
        {
            get
            {
                var dag = new Dag(DateTime.Now);
                PopulateMaandag(dag);
                PopulateDinsdag(dag);
                PopulateWoensdag(dag);
                PopulateDonderdag(dag);
                PopulateVrijdag(dag);
                return dag.Vakken
                    .Select(v => v.Naam)
                    .Distinct()
                    .OrderBy(v => v)
                    .ToList();
            }
        }
    }
}