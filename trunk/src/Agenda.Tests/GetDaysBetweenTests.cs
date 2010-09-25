using System.Linq;
using Agendas.Entities;
using Agendas.Extensions;
using Agendas.Infrastructure;
using Agendas.Queries;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Agenda.Tests
{
    public class GetDaysBetweenTests : InMemoryDataAccessTest
    {
        protected override void PrepareData()
        {
            session.Save(new Dag(22.September(2010)));
            session.Save(new Dag(20.September(2010)));
            session.Save(new Dag(28.September(2010)));
            session.Save(new Dag(26.September(2010)));
            session.Save(new Dag(24.September(2010)));
        }

        [Test]
        public void should_be_able_to_get_all_days_between_september_23_and_25()
        {
            var days = session.Query(new GetDaysBetween(23.September(2010), 25.September(2010))).List();
            Assert.That(days.Count(), Is.EqualTo(1));
            Assert.That(days.First(), Is.InstanceOf<Dag>());
            Assert.That(days.First().Date, Is.EqualTo(24.September(2010)));
        }

        [Test]
        public void should_be_able_to_get_all_days_between_september_20_and_28()
        {
            var days = session.Query(new GetDaysBetween(20.September(2010), 28.September(2010))).List();
            Assert.That(days.Count(), Is.EqualTo(5));
            Assert.That(days.First().Date, Is.EqualTo(20.September(2010)));
            Assert.That(days.Last().Date, Is.EqualTo(28.September(2010)));
        }

    }
}