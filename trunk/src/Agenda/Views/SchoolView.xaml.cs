using System;
using System.Collections.Generic;
using System.Windows;
using Agenda.Extensions;
using Agenda.Presentation;

namespace Agenda.Views
{
    public partial class SchoolView : Window, ISchoolAgendaView
    {
        public event EventHandler SaveChanges;
        public IList<ICourse> Courses { get; private set; }

        public SchoolView()
        {
            InitializeComponent();
            InitializeCourses();
        }

        private void InitializeCourses()
        {
            Courses = new List<ICourse> {vak1, vak2, vak3, vak4, vak5, vak6, vak7};
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            SaveChanges.Raise(this, EventArgs.Empty);
        }
    }
}