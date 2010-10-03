using Agendas.Events;
using Agendas.Infrastructure;
using Agendas.Queries;

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
            view.Vakken = DagFactory.AlleVakken;
        }

        public void CreateTaak()
        {
            using(var session = NHibernateProvider.CreateSession())
            using(var transaction = session.BeginTransaction())
            {
                var dag = session.Query(new GetDayQuery(view.DateDue)).UniqueResult();
                if (dag == null)
                {
                    dag = DagFactory.CreateDag(view.DateDue);
                    session.Save(dag);
                }
                dag.AddTaak(view.SelectedVak, view.Inhoud);
                transaction.Commit();
            }
            EventAggregator.Raise(new TaakHasBeenCreated());
        }
    }
}