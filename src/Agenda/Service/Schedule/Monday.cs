namespace Agenda.Service
{
    public class Monday : WeekDay
    {
        // Ma: SOAC, FRA, BIO, FRA, PO, PO, NED
        public Monday()
        {
            courses.Add(1, "SOAC");
            courses.Add(2, "FRA");
            courses.Add(3, "BIO");
            courses.Add(4, "FRA");
            courses.Add(5, "PO");
            courses.Add(6, "PO");
            courses.Add(7, "NED");
        }
    }
}