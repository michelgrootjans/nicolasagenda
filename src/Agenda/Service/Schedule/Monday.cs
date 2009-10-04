namespace Agenda.Service
{
    public class Monday : WeekDay
    {
        // Ma: SOAC, FRA, BIO, FRA, PO, PO, NED
        public Monday()
        {
            courses.Add(0, "SOAC");
            courses.Add(1, "FRA");
            courses.Add(2, "BIO");
            courses.Add(3, "FRA");
            courses.Add(4, "PO");
            courses.Add(5, "PO");
            courses.Add(6, "NED");
        }
    }
}