using System.Windows.Forms;

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
    }
}
