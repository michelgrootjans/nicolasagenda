using System;
using System.Collections.Generic;
using Agenda.Service.Roster;

namespace Agenda.Service
{
    internal interface ISchedule
    {
        string CourseAt(DateTime date);
        string CourseAt(DateTime date, int hour);
        IEnumerable<string> CoursesAt(DateTime date);
    }

    public class Schedule : ISchedule
    {
        public string CourseAt(DateTime date)
        {
            return GetWeekDay(date).CourseAt(date.TimeOfDay);
        }

        public string CourseAt(DateTime date, int hour)
        {
            return GetWeekDay(date).CourseAt(hour);
        }

        public IEnumerable<string> CoursesAt(DateTime date)
        {
            return GetWeekDay(date).Courses;
        }

        private static WeekDay GetWeekDay(DateTime time)
        {
            switch(time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return new Monday();
                case DayOfWeek.Tuesday:
                    return new Tuesday();
                case DayOfWeek.Wednesday:
                    return new Wednesday();
                case DayOfWeek.Thursday:
                    return new Thursday();
                case DayOfWeek.Friday:
                    return new Friday();
                default:
                    return new WeekendDay();
            }
        }
    }
}