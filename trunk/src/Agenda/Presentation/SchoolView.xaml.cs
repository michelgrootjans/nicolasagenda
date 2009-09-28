using System;
using System.Windows;
using System.Windows.Controls;
using Agenda.Extensions;
using Agenda.Service;

namespace Agenda.Presentation
{
    /// <summary>
    /// Interaction logic for SchoolView.xaml
    /// </summary>
    public partial class SchoolView : Window, IView
    {
        private readonly IScheduleService service;
        private readonly DateTime date;

        public SchoolView()
        {
            InitializeComponent();
        }

        public SchoolView(IScheduleService service, DateTime date) : this()
        {
            this.service = service;
            this.date = date;
            InitializeDay();
        }

        private void InitializeDay()
        {
            foreach(var course in service.CoursesFor(date))
                AddToView(course);
        }

        private void AddToView(string course)
        {
            var vak = new Vak(course);
            vakken.Children.Add(vak);
        }

        private void FillControl(ContentControl button, int hour)
        {
            var content = service.CourseAt(date, hour);
            if (content.IsNullOrEmty())
                button.Visibility = Visibility.Hidden;
            else button.Content = content;
        }
    }
}