using System;
using Agendas.Entities;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public class DagPresenter : Presenter, IPresenter<DayView>
    {
        private readonly IDagView dagView;

        public DagPresenter(IDagView dagView)
        {
            this.dagView = dagView;
        }

        public void Initialize()
        {
            dagView.Dag = GetOrCreateDag(dagView.Date);
        }

        private IDag GetOrCreateDag(DateTime dateTime)
        {
            var dag = Session.Query(new GetDayQuery(dateTime)).UniqueResult()
                      ?? DagFactory.CreateDag(dateTime);
            return dag;
        }

        protected override void SaveIfChanged()
        {
            if (dagView.HasChanged)
                using (var transaction = Session.BeginTransaction())
                {
                    Session.SaveOrUpdate(dagView.Dag);
                    transaction.Commit();
                }
        }
    }
}