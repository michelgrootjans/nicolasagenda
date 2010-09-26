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

        private void btnVandaag_Click(object sender, System.EventArgs e)
        {
            Show(new DayView());
        }

        private void Show(Form dayView)
        {
            dayView.MdiParent = this;
            dayView.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {
            Show(new DayView(dateTimePicker.Value));
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            EventAggregator.Raise(new PrintCurrentViewEvent());
        }

        private void AgendaView_Load(object sender, System.EventArgs e)
        {
            Show(new DayView(new DateTime(2010, 9, 27)));
            EventAggregator.Raise(new PrintCurrentViewEvent());
            Close();
        }
    }
}
