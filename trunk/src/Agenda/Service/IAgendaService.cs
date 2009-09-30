using System;
using System.Collections.Generic;
using Agenda.Presentation;

namespace Agenda.Service
{
    public interface IAgendaService
    {
        IDictionary<int, ICourse> GetContentFor(DateTime date);
    }

    class AgendaService : IAgendaService
    {
        public IDictionary<int, ICourse> GetContentFor(DateTime date)
        {
            IDictionary<int, ICourse> dayContent = new Dictionary<int, ICourse>
                                                       {
                                                           {1, new Course("", "")},
                                                           {2, new Course("", "")},
                                                           {3, new Course("", "")},
                                                           {4, new Course("", "")},
                                                           {5, new Course("", "")},
                                                           {6, new Course("", "")},
                                                           {7, new Course("", "")}
                                                       };
            return dayContent;
        }
    }

    public class Course : ICourse
    {
        public string CourseName { get; set; }
        public string CourseContent { get; set; }

        public Course(string courseName, string courseContent)
        {
            CourseName = courseName;
            CourseContent = courseContent;
        }
    }
}