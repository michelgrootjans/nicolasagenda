namespace Agenda.Service
{
    // Wo: AAR, WIS, GOD, NED

    internal class Wednesday : WeekDay
    {
        public Wednesday()
        {
            courses.Add(1, "AAR");
            courses.Add(2, "WIS");
            courses.Add(3, "GOD");
            courses.Add(4, "NED");

        }
    }
}