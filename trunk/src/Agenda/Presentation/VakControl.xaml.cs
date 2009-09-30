using System.Windows;
using System.Windows.Controls;
using Agenda.Extensions;
using Agenda.Presentation;

namespace Agenda.Views
{
    public partial class VakControl : UserControl, ICourse
    {
        public VakControl()
        {
            InitializeComponent();
        }

        public string CourseName
        {
            get { return vakNaam.Content as string; }
            set
            {
                vakNaam.Content = value;
                Visibility = value.IsNullOrEmty() 
                    ? Visibility.Hidden 
                    : Visibility.Visible;
            }
        }

        public string CourseContent
        {
            get { return lesInhoud.Text; }
            set { lesInhoud.Text = value; }
        }
    }
}