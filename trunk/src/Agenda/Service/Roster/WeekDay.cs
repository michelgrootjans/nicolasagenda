using System;
using System.Collections.Generic;
using Agenda.Extensions;

namespace Agenda.Service.Roster
{
    public abstract class WeekDay
    {
        protected readonly IDictionary<int, string> courses;
        private readonly TimeSpan beginLes1;
        private readonly TimeSpan beginLes2;
        private readonly TimeSpan beginLes3;
        private readonly TimeSpan beginLes4;
        private readonly TimeSpan beginLes5;
        private readonly TimeSpan beginLes6;
        private readonly TimeSpan beginLes7;
        private readonly TimeSpan eindeVanDeDag;

        protected WeekDay()
        {
            courses = new Dictionary<int, string>();
            beginLes1 = new TimeSpan(8, 25, 00);
            beginLes2 = new TimeSpan(9, 15, 00);
            beginLes3 = new TimeSpan(10, 20, 00);
            beginLes4 = new TimeSpan(11, 10, 00);
            beginLes5 = new TimeSpan(12, 55, 00);
            beginLes6 = new TimeSpan(13, 45, 00);
            beginLes7 = new TimeSpan(14, 50, 00);
            eindeVanDeDag = new TimeSpan(16, 00, 00);
        }

        public IEnumerable<string> Courses
        {
            get { return courses.Values; }
        }

        public string CourseAt(TimeSpan timeOfDay)
        {
            return CourseAt(LesuurVoor(timeOfDay));
        }

        public string CourseAt(int hour)
        {
            return courses.ContainsKey(hour) ? courses[hour] : "";
        }

        private int LesuurVoor(TimeSpan timeOfDay)
        {
            if (timeOfDay.IsMoreThanOrEqualTo(eindeVanDeDag))
                return -1;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes7))
                return 6;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes6))
                return 5;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes5))
                return 4;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes4))
                return 3;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes3))
                return 2;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes2))
                return 1;
            if (timeOfDay.IsMoreThanOrEqualTo(beginLes1))
                return 0;
            return -1;
        }
    }
}