﻿using System;
using System.Windows.Forms;
using Agendas.Events;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public partial class AgendaView : Form
    {
        public AgendaView()
        {
            InitializeComponent();
        }

        private void AgendaView_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;

            Show(new DayView());
            //EventAggregator.Raise(new PrintCurrentViewEvent());
        }

        private void btnVandaag_Click(object sender, EventArgs e)
        {
            Show(new DayView());
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Show(new DayView(dateTimePicker.Value));
        }

        private void btnPrintWeek_Click(object sender, EventArgs e)
        {
            EventAggregator.Raise(new PrintCurrentViewEvent());
        }

        private void btnPrintMaand_Click(object sender, EventArgs e)
        {
            EventAggregator.Raise(new PrintCurrentMonthEvent());
        }

        private void Show(Form dayView)
        {
            dayView.MdiParent = this;
            dayView.Show();
        }
    }
}