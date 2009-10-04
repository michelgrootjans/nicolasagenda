using System;
using System.Windows;
using System.Windows.Controls;
using Agenda.Extensions;

namespace Agenda.Views
{
    /// <summary>
    /// Interaction logic for DateButton.xaml
    /// </summary>
    public partial class DateButton : UserControl
    {
        public EventHandler<ShowViewEventArgs> ShowNewView;

        public DateButton()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return button.Content as string; }
            set { button.Content = value; }
        }

        public DateTime Value { get; set; }

        private void SelectNewView(object sender, RoutedEventArgs e)
        {
            ShowNewView.Raise(this, new ShowViewEventArgs(Value));
        }
    }

    public class ShowViewEventArgs : EventArgs
    {
        private readonly DateTime value;

        public ShowViewEventArgs(DateTime value)
        {
            this.value = value;
        }

        public DateTime Value
        {
            get { return value; }
        }
    }
}