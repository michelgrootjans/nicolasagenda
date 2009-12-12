using System;
using System.Collections.Generic;
using Agenda.Extensions;

namespace Agenda.ViewModels
{
    [Serializable]
    public class Dag
    {
        public DateTime Date { get; set; }
        public List<Course> Courses { get; set; }
        public string Taken { get; set; }
        public string Lessen { get; set; }

        public Dag()
        {
            Courses = new List<Course>();
        }

        public Dag(IList<Course> courses, IList<string> schedule)
        {
            Courses = new List<Course>(courses);
            for (var hour = 0; hour < schedule.Count; hour++)
            {
                if (Courses.Count <= hour)
                    Courses.Add(new Course(schedule[hour], null));
                else if (courses[hour].Vak.IsNullOrEmpty())
                    Courses[hour].Vak = schedule[hour];
            }
        }

        public Course this[int index]
        {
            get { return Courses[index]; }
            set { Courses[index] = value; }
        }
    }
}