using Agendas.Entities;
using NUnit.Framework;
using Agendas.Extensions;

namespace Agenda.Tests
{
    [TestFixture]
    public class DagTests
    {
        [Test]
        public void Maandag_should_return_DOW_1()
        {
            var dag = new Dag(20.September(2010));
            Assert.That(dag.DayOfWeek, Is.EqualTo(0));
        }

        [Test]
        public void Dinsdag_should_return_DOW_2()
        {
            var dag = new Dag(21.September(2010));
            Assert.That(dag.DayOfWeek, Is.EqualTo(1));
        }

        [Test]
        public void Vrijdag_should_return_DOW_5()
        {
            var dag = new Dag(24.September(2010));
            Assert.That(dag.DayOfWeek, Is.EqualTo(4));
        }

    }
}