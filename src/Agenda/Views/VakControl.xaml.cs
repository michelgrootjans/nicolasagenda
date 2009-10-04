﻿using System.Windows;
using System.Windows.Controls;
using Agenda.Extensions;
using Agenda.Presentation;

namespace Agenda.Views
{
    public partial class VakControl : UserControl, ICourse
    {
        private int uur = -1;

        public VakControl()
        {
            InitializeComponent();
        }

        public int Uur
        {
            get { return uur; }
            set
            {
                uur = value;
                vakUur.Content = uur + 1;
            }
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