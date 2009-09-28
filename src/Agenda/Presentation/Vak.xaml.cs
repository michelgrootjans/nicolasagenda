using System.Windows.Controls;

namespace Agenda.Presentation
{
    /// <summary>
    /// Interaction logic for Vak.xaml
    /// </summary>
    public partial class Vak : UserControl
    {
        private readonly string course;

        public Vak()
        {
            InitializeComponent();
        }

        public Vak(string course)
        {
            this.course = course;
        }
    }
}