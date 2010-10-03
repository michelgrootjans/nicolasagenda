using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Agendas.Entities;
using Agendas.Events;
using Agendas.Infrastructure;
using Agendas.Queries;

namespace Agendas.Views
{
    public partial class _taakView : UserControl, ITaakView
    {
        private ITaakPresenter presenter;

        public _taakView()
        {
            InitializeComponent();
        }

        private void _taakView_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
            presenter = new TaakPresenter(this);
            presenter.Initialize();
        }

        public IList<ITaak> Taken
        {
            set
            {
                taken.Items.Clear();
                foreach (var taak in value)
                    taken.Items.Add(taak.Beschrijving, taak.IsAf);
            }
        }

        private void btnNieuweTaak_Click(object sender, EventArgs e)
        {
            var form = new MaakTaakView();
            form.Show();
        }

        public void SetTaken(IEnumerable<ITaak> taken)
        {
            Taken = new List<ITaak>(taken);
        }

        private void taken_DoubleClick(object sender, EventArgs e)
        {
        }
    }

    internal class TaakPresenter : Presenter, ITaakPresenter, IListenTo<TaakHasBeenCreated>
    {

        public TaakPresenter(ITaakView view)
        {
        }

        public void Initialize()
        {
            //using (var session = NHibernateProvider.CreateSession())
            //{
            //    var taken = session.Query(new GetDueTaken()).List();
            //    view.Taken = taken.Cast<ITaak>();
            //}
        }

        public void HandleEvent(TaakHasBeenCreated domainEvent)
        {
            Initialize();
        }
    }

    internal interface ITaakView
    {
        IList<ITaak> Taken { set; }
    }

    internal interface ITaakPresenter
    {
        void Initialize();
    }
}