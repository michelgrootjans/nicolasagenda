using System;
using System.Linq;
using Agendas.Entities;
using Agendas.Views;
using NHibernate.Criterion;
using NUnit.Framework;
using Agendas.Infrastructure;

namespace Agenda.Tests
{
    public class DagCrud : InMemoryDataAccessTest
    {
        protected override void PrepareData()
        {
            session.Save(new Dag(DateTime.Now));
        }

        [Test]
        public void query_dag_should_work()
        {
            var dag = session.Query(new GetDayQuery(DateTime.Now))
                .UniqueResult();
            Assert.That(dag.Date == DateTime.Today);
        }

        [Test]
        public void add_vak_should_work()
        {
            var dag = GetDag();
            dag.AddVak(1, "FRA", "Vandaag heb ik iets geleerd");
            FlushAndClear();

            var dagFromDb = session.Query(new GetDayQuery(DateTime.Now))
                .UniqueResult();
            Assert.That(dagFromDb.Vakken.Count(), Is.EqualTo(1));
            var lesUur = dagFromDb.Vakken.First();
            Assert.That(lesUur.Uur, Is.EqualTo(1));
            Assert.That(lesUur.Naam, Is.EqualTo("FRA"));
            Assert.That(lesUur.Inhoud, Is.EqualTo("Vandaag heb ik iets geleerd"));
        }

        [Test]
        public void add_taak_should_work()
        {
            var dag = GetDag();
            dag.AddTaak("FRA", "Toets verbeteren");
            FlushAndClear();

            var dagFromDb = session.Query(new GetDayQuery(DateTime.Now))
                .UniqueResult();
            Assert.That(dagFromDb.Taken.Count(), Is.EqualTo(1));
            var taak = dagFromDb.Taken.First();
            Assert.That(taak.Vak, Is.EqualTo("FRA"));
            Assert.That(taak.Inhoud, Is.EqualTo("Toets verbeteren"));
        }


        private Dag GetDag()
        {
            var criteria = session.CreateCriteria<Dag>()
                .Add(Restrictions.Eq("Date", DateTime.Today));
            return criteria.UniqueResult<Dag>();
        }
    }
}