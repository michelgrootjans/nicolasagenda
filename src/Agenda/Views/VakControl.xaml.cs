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

        public int Uur
        {
            get
            {
                if (vakUur.Content.IsNull())
                    return -1;
                return (int) vakUur.Content;
            }
            set { vakUur.Content = value; }
        }

        public string Vak
        {
            get { return vakNaam.Content as string; }
            set
            {
                vakNaam.Content = value;
                Visibility = value.IsNullOrEmpty()
                                 ? Visibility.Hidden
                                 : Visibility.Visible;
            }
        }

        public string Inhoud
        {
            get { return lesInhoud.Text; }
            set { lesInhoud.Text = value; }
        }
    }
}