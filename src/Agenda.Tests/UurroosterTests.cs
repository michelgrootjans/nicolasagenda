using System;
using Agendas.Entities;
using Agendas.Extensions;
using NUnit.Framework;

namespace Agenda.Tests
{
    [TestFixture]
    public class UurroosterTests
    {
        private IUurroorster uurrooster;

        [SetUp]
        public void SetUp()
        {
            uurrooster = new Uurrooster();
        }


        [Test]
        public void Nieuw_uurrrooster_heeft_geen_vakken()
        {
            Assert.That(uurrooster.VakVoor(DateTime.Now), Is.Null);
        }

        [Test]
        public void Vak_toevoegen_geeft_vak_terug()
        {
            var nederlands = new Vak("NED", "Nederlands");
            uurrooster.Maandag[1] = nederlands;

            Assert.That(uurrooster.VakVoor(6.September(2010).At(9)), Is.SameAs(nederlands));
        }
    }
}