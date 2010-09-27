using System;
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
            Show(new DayView());
            //Show(new DayView(new DateTime(2010, 9, 27)));
            //EventAggregator.Raise(new PrintCurrentViewEvent());
            //Show(new DayView(new DateTime(2010, 9, 30)));
            //EventAggregator.Raise(new PrintCurrentViewEvent());
            //Close();
        }

        private void btnVandaag_Click(object sender, EventArgs e)
        {
            Show(new DayView());
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Show(new DayView(dateTimePicker.Value));
        }

        private void btnNieuweTaak_Click(object sender, EventArgs e)
        {
            Show(new MaakTaakView());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            EventAggregator.Raise(new PrintCurrentViewEvent());
        }

        private void Show(Form dayView)
        {
            dayView.MdiParent = this;
            dayView.Show();
        }
    }
}