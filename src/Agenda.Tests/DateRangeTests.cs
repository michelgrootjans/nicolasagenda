using Agendas.Views;
using NUnit.Framework;
using Agendas.Extensions;

namespace Agenda.Tests
{
    [TestFixture]
    public class DateRangeTests
    {
        [Test]
        public void mondayEvent_should_get_monday_to_wednesday()
        {
            var range = new PageDayRange(20.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(20.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(22.September(2010)));
        }

        [Test]
        public void tuesdayEvent_should_get_monday_to_wednesday()
        {
            var range = new PageDayRange(21.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(20.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(22.September(2010)));
        }

        [Test]
        public void wednesdayEvent_should_get_monday_to_wednesday()
        {
            var range = new PageDayRange(22.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(20.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(22.September(2010)));
        }

        [Test]
        public void thursdayEvent_should_get_thursday_to_friday()
        {
            var range = new PageDayRange(23.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(23.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(24.September(2010)));
        }

        [Test]
        public void fridayEvent_should_get_thursday_to_friday()
        {
            var range = new PageDayRange(24.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(23.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(24.September(2010)));
        }

        [Test]
        public void saturdayEvent_should_get_thursday_to_friday()
        {
            var range = new PageDayRange(25.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(23.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(24.September(2010)));
        }

        [Test]
        public void sundayEvent_should_get_thursday_to_friday()
        {
            var range = new PageDayRange(26.September(2010));
            Assert.That(range.StartDate, Is.EqualTo(23.September(2010)));
            Assert.That(range.EndDate, Is.EqualTo(24.September(2010)));
        }

    }
}