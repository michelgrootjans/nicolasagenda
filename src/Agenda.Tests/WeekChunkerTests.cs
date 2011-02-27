using System;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;
using Agendas.Extensions;
using Agendas.Views.Printing;
using NUnit.Framework;

namespace Agenda.Tests
{
    [TestFixture]
    public class WeekChunkerTests
    {
        private Dag maandag14;
        private Dag dinsdag15;
        private Dag woensdag16;
        private Dag donderdag17;
        private Dag vrijdag18;

        [SetUp]
        public void SetUp()
        {
            maandag14 = new Dag(14.March(2011));
            dinsdag15 = new Dag(15.March(2011));
            woensdag16 = new Dag(16.March(2011));
            donderdag17 = new Dag(17.March(2011));
            vrijdag18 = new Dag(18.March(2011));
        }

        [Test]
        public void monday_to_wednesday()
        {
            var chunker = new WeekChunker(new List<IDag> {maandag14, dinsdag15, woensdag16});
            Assert.That(chunker.Count(), Is.EqualTo(1));
            var weekChunk = chunker.First();
            Assert.That(weekChunk.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
            Assert.That(weekChunk.Days.Count(), Is.EqualTo(3));
            Assert.That(weekChunk.Days, Contains.Item(maandag14));
            Assert.That(weekChunk.Days, Contains.Item(dinsdag15));
            Assert.That(weekChunk.Days, Contains.Item(woensdag16));
        }

        [Test]
        public void thirsday_to_friday()
        {
            var chunker = new WeekChunker(new List<IDag> {donderdag17, vrijdag18});
            Assert.That(chunker.Count(), Is.EqualTo(1));
            var weekChunk = chunker.First();
            Assert.That(weekChunk.DayOfWeek, Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(weekChunk.Days.Count(), Is.EqualTo(2));
            Assert.That(weekChunk.Days, Contains.Item(donderdag17));
            Assert.That(weekChunk.Days, Contains.Item(vrijdag18));
        }

        [Test]
        public void monday_to_friday()
        {
            var chunker = new WeekChunker(new List<IDag> { maandag14, dinsdag15, woensdag16, donderdag17, vrijdag18 });
            Assert.That(chunker.Count(), Is.EqualTo(2));
            var moToWed = chunker.First();
            Assert.That(moToWed.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
            Assert.That(moToWed.Days.Count(), Is.EqualTo(3));
            Assert.That(moToWed.Days, Contains.Item(maandag14));
            Assert.That(moToWed.Days, Contains.Item(dinsdag15));
            Assert.That(moToWed.Days, Contains.Item(woensdag16));
            var thAndFr = chunker.Last();
            Assert.That(thAndFr.DayOfWeek, Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(thAndFr.Days.Count(), Is.EqualTo(2));
            Assert.That(thAndFr.Days, Contains.Item(donderdag17));
            Assert.That(thAndFr.Days, Contains.Item(vrijdag18));
        }
    }
}