using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Agendas.Entities;
using Agendas.Extensions;
using Agendas.Queries;
using NUnit.Framework;
using Agendas.Infrastructure;

namespace Agenda.Tests
{
    public class GetDueTakenTests : InMemoryDataAccessTest
    {
        protected override void PrepareData()
        {
            var dag = new Dag(20.September(2010));
            dag.AddTaak("FRA", "Ik moet hard werken");
            dag.AddTaak("NED", "Ik moet heel hard werken");
            session.Save(dag);
        }

        [Test]
        public void should_be_able_to_get_all_taken()
        {
            var taken = session.Query(new GetDueTaken()).List();
            Assert.That(taken.Count(), Is.EqualTo(2));
        }

        [Test]
        public void should_be_able_to_get_dag()
        {
            var taken = session.Query(new GetDueTaken()).List();
            Assert.That(taken.First(), Is.EqualTo(2));
        }
    }
}