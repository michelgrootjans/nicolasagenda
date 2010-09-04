using System;
using System.Windows.Forms;
using Agendas.Infrastructure;
using Agendas.Queries;

namespace Agendas.Views
{
    public partial class DayView : MdiChild, IEventHandler<GetDayResult>
    {
        public DayView()
        {
            InitializeComponent();
            Initialize(DateTime.Now);
        }

        private void Initialize(DateTime date)
        {
            Text = date.ToShortDateString();
            Execute.Query<GetDay, GetDayResult>(new GetDay(date));
        }

        public void HandleEvent(GetDayResult domainEvent)
        {
            MessageBox.Show(string.Format("Recieved an {0}", domainEvent));
        }
    }
}