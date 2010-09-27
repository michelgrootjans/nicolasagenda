using System.Collections.Generic;
using Agendas.Events;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    internal class MaakTaakPresenter : IMaakTaakPresenter
    {
        private readonly IMaakTaakView view;

        public MaakTaakPresenter(IMaakTaakView view)
        {
            this.view = view;
        }

        public void Initilaize()
        {
            view.Vakken = new List<string>{"FRA", "NED"};
        }

        public void CreateTaak()
        {
            using(var session = NHibernateProvider.CreateSession())
            using(var transaction = session.BeginTransaction())
            {
                var dag = session.Query(new GetDayQuery(view.DateDue)).UniqueResult() ??
                          DagFactory.CreateDag(view.DateDue);
                dag.AddTaak(view.SelectedVak, view.Inhoud);
                transaction.Commit();
            }
            EventAggregator.Raise(new TaakHasBeenCreated());
        }
    }
}