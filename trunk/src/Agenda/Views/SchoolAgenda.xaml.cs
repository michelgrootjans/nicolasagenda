using System;
using System.ComponentModel;
using System.Windows;
using Agenda.Presentation;
using Agenda.Extensions;

namespace Agenda.Views
{
    /// <summary>
    /// Interaction logic for SchoolAgenda.xaml
    /// </summary>
    public partial class SchoolAgenda : Window
    {
        private readonly IWindowManager windowManager;
        private IView view;

        public SchoolAgenda()
        {
            InitializeComponent();
        }

        public SchoolAgenda(IWindowManager windowManager) : this()
        {
            this.windowManager = windowManager;
            InitNavigation();
            InitContent();
        }

        private void InitNavigation()
        {
            InsertButton("Vrijdag",2.Oktober(2009).At(9, 00));
            InsertButton("Maandag",5.Oktober(2009).At(9, 00));
            InsertButton("Dinsdag",6.Oktober(2009).At(9, 00));
            InsertButton("Woensdag",7.Oktober(2009).At(9, 00));
            InsertButton("Donderdag",8.Oktober(2009).At(9, 00));
            InsertButton("Vrijdag",9.Oktober(2009).At(9, 00));
        }

        private void InsertButton(string label, DateTime value)
        {
            var button = new DateButton { Label = label, Value = value };
            button.ShowNewView += UpdateView;
            navigation.Children.Add(button);
        }

        private void UpdateView(object sender, ShowViewEventArgs e)
        {
            SaveView();
            Title = e.Value.ToLongDateString();
            SetView(windowManager.GetViewAt(e.Value));
        }

        private void SetView(IView view)
        {
            this.view = view;
            content.Children.Clear();
            content.Children.Add(view as UIElement);
        }

        private void InitContent()
        {
            SetView(windowManager.GetViewAt(5.Oktober(2009).At(9, 00)));
        }

        private void SaveView(object sender, CancelEventArgs e)
        {
            SaveView();
        }

        private void SaveView()
        {
            if (view.IsNotNull())
                view.Save();
        }
    }
}