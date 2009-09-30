namespace Agenda.Service
{ 
    //* Do: FRA, WIS, MO, WIS, FRA, NED, LO
    internal class Thursday : WeekDay
    {
        public Thursday()
        {
            courses.Add(1, "FRA");
            courses.Add(2, "WIS");
            courses.Add(3, "MO");
            courses.Add(4, "WIS");
            courses.Add(5, "FRA");
            courses.Add(6, "NED");
            courses.Add(7, "LO");
        }
    }
}