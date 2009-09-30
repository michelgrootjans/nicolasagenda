using System;
using System.Collections.Generic;
using System.Windows;
using Agenda.Presentation;

namespace Agenda.Views
{
    /// <summary>
    /// Interaction logic for SchoolView.xaml
    /// </summary>
    public partial class SchoolView : Window, ISchoolAgendaView
    {
        private IDictionary<int, VakControl> courses;

        public SchoolView()
        {
            InitializeComponent();
            InitializeCourses();
        }

        private void InitializeCourses()
        {
            courses = new Dictionary<int, VakControl>
                          {
                              {1, vak1},
                              {2, vak2},
                              {3, vak3},
                              {4, vak4},
                              {5, vak5},
                              {6, vak6},
                              {7, vak7}
                          };
        }

        //public void SetCourse(int hour, string courseName, string courseContent)
        //{
        //    var c = courses[hour];
        //    c.Visibility = Visibility.Visible;
        //    c.CourseName = courseName;
        //    c.CourseContent = courseContent;
        //}

        public ICourse GetCourse(int hour)
        {
            return courses[hour];
        }
    }
}