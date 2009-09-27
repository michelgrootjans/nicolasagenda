namespace Agenda.Services
{
    public interface IScheduleService
    {
        bool LessonIsOngoing { get; }
    }

    public class ScheduleService : IScheduleService
    {
        public bool LessonIsOngoing
        {
            get { return true; }
        }
    }

    /*
     * 8:25
     * 9:15 - 10:05
     * 
     * 10:20
     * 11:10 - 12:00
     * 
     * 12:55
     * 13:45 - 14:35
     * 
     * 14:50
     * 15:40 - 15:40
     * 
     * Ma: SOAC, FRA, BIO, FRA, PO, PO, NED
     * Di: NED, GOD, TO, TO, WIS, NED, FRA
     * Wo: AAR, WIS, GOD, NED
     * Do: FRA, WIS, MO, WIS, FRA, NED, LO
     * Vr: LO, FRA, BIO, NED, GES, AAR, WIS
     * 
     */
}