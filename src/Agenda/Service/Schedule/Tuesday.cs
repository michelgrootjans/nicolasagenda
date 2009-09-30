namespace Agenda.Service
{ 
    // Di: NED, GOD, TO, TO, WIS, NED, FRA
    internal class Tuesday : WeekDay
    {
        public Tuesday()
        {
            courses.Add(1, "NED");
            courses.Add(2, "GOD");
            courses.Add(3, "TO");
            courses.Add(4, "TO");
            courses.Add(5, "WIS");
            courses.Add(6, "NED");
            courses.Add(7, "FRA");
        }
    }
}