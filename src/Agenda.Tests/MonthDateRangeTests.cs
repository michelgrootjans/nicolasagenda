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
        public void februari2011()
        {
            AssertRange(7.Februari(2011), 4.March(2011));
        }

        [Test]
        public void march2011()
        {
            AssertRange(14.March(2011), 1.April(2011));
        }

        [Test]
        public void april2011()
        {
            AssertRange(4.April(2011), 29.April(2011));
        }

        [Test]
        public void may2011()
        {
            AssertRange(2.May(2011), 3.June(2011));
        }

        [Test]
        public void june2011()
        {
            AssertRange(6.June(2011), 3.July(2011));
        }

        [Test]
        public void september2011()
        {
            AssertRange(1.September(2011), 30.September(2011));
        }

        [Test]
        public void oktober2011()
        {
            AssertRange(3.October(2011), 28.October(2011));
        }

        [Test]
        public void november2011()
        {
            AssertRange(7.November(2011), 2.December(2011));
        }

        [Test]
        public void december2011()
        {
            AssertRange(5.December(2011), 23.December(2011));
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