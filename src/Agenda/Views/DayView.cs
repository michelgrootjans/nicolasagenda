using System;
using Agendas.Commands;
using Agendas.Infrastructure;
using Agendas.Queries;

namespace Agendas.Views
{
    public partial class DayView : MdiChild, IListenTo<GetDayResponse>
    {
        private readonly DateTime date = DateTime.Today;

        public DayView()
        {
            InitializeComponent();
        }

        public DayView(DateTime date)
        {
            InitializeComponent();
            this.date = date.Date;
        }

        private void DayView_Load(object sender, EventArgs e)
        {
            Execute.Request<GetDayRequest, GetDayResponse>(new GetDayRequest(date));
        }

        public void HandleEvent(GetDayResponse domainEvent)
        {
            if(domainEvent.Date.Equals(date))
                Text = domainEvent.Date.ToLongDateString();
        }

        private void DayView_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Execute.Command(new SaveDay(date));
        }
    }
}