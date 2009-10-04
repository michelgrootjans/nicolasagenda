using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Agenda.Extensions;
using Agenda.Presentation;

namespace Agenda.Views
{
    public partial class SchoolView : UserControl, ISchoolAgendaView
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
            Courses = new List<ICourse> {vak0, vak1, vak2, vak3, vak4, vak5, vak6};
        }

        public void Save()
        {
            SaveChanges.Raise(this, EventArgs.Empty);
        }
    }
}