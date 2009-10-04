namespace Agenda.Service
{
    // Wo: AAR, WIS, GOD, NED

    internal class Wednesday : WeekDay
    {
        public Wednesday()
        {
            courses.Add(0, "AAR");
            courses.Add(1, "WIS");
            courses.Add(2, "GOD");
            courses.Add(3, "NED");

        }
    }
}