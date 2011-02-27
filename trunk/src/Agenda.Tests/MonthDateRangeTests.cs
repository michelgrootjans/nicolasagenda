using System;
using Agendas.Views;
using NUnit.Framework;
using Agendas.Extensions;

namespace Agenda.Tests
{
    [TestFixture]
    public class MonthDayRangeTests
    {
        [Test]
        public void februari()
        {
            AssertRange(7.Februari(2011), 4.March(2011));
        }

        [Test]
        public void march()
        {
            AssertRange(7.March(2011), 1.April(2011));
        }

        [Test]
        public void april()
        {
            AssertRange(4.April(2011), 29.April(2011));
        }

        [Test]
        public void may()
        {
            AssertRange(2.May(2011), 3.June(2011));
        }

        [Test]
        public void june()
        {
            AssertRange(6.June(2011), 3.July(2011));
        }

        private void AssertRange(DateTime start, DateTime end)
        {
            AssertDate(start, start, end);
            AssertDate(start, start.AddDays(10), end);
            AssertDate(start, end.AddDays(-10), end);
            AssertDate(start, end, end);
        }

        private void AssertDate(DateTime start, DateTime actual, DateTime end)
        {
            var startRange = new MonthDayRange(actual);
            Assert.That(startRange.StartDate, Is.EqualTo(start));
            Assert.That(startRange.EndDate, Is.EqualTo(end));
        }
    }
}