using System;
using System.Windows;
using Agenda.Presentation;

namespace Agenda.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window, IView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}