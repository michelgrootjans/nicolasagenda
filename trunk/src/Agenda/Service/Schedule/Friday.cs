namespace Agenda.Service
{
    // * Vr: LO, FRA, BIO, NED, GES, AAR, WIS
    internal class Friday : WeekDay
    {
        public Friday()
        {
            courses.Add(1, "LO");
            courses.Add(2, "FRA");
            courses.Add(3, "BIO");
            courses.Add(4, "NED");
            courses.Add(5, "GES");
            courses.Add(6, "AAR");
            courses.Add(7, "WIS");
        }
    }
}