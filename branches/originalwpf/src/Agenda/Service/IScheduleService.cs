using System;
using System.Collections.Generic;
using Agenda.Extensions;

namespace Agenda.Service
{
    public interface IScheduleService
    {
        bool SchoolIsOngoingOn(DateTime date);
        string CurrentCourseAt(DateTime date);
        string CourseAt(DateTime date, int hour);
        IEnumerable<string> CoursesFor(DateTime date);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly ISchedule schedule;

        public ScheduleService()
        {
            schedule = new Schedule();
        }

        public bool SchoolIsOngoingOn(DateTime date)
        {
            return schedule.CourseAt(date).IsNotNullOrEmpty();
        }

        public string CurrentCourseAt(DateTime date)
        {
            return schedule.CourseAt(date);
        }

        public string CourseAt(DateTime date, int hour)
        {
            return schedule.CourseAt(date, hour);
        }

        public IEnumerable<string> CoursesFor(DateTime date)
        {
            return schedule.CoursesAt(date);
        }
    }
}