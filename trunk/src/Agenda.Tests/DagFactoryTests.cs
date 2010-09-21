using System;
using System.Linq;
using Agendas.Entities;
using Agendas.Extensions;
using Agendas.Views;
using NUnit.Framework;

namespace Agenda.Tests
{
    [TestFixture]
    public abstract class DagFactoryTests
    {
        protected IDag dag;

        [SetUp]
        public void SetUp()
        {
            dag = CreateDag();
        }

        protected abstract IDag CreateDag();

        protected void CheckLesuur(int lesuur, string vak)
        {
            Assert.That(dag[lesuur].Naam, Is.EqualTo(vak));
        }
    }

    public class DagFactoryMaandagTests : DagFactoryTests
    {
        private readonly DateTime maandag = 20.September(2010);

        protected override IDag CreateDag()
        {
             return DagFactory.CreateDag(maandag);
        }

        [Test]
        public void eerste_lesuur_WIS()
        {
            CheckLesuur(1, "WIS");
        }

        [Test]
        public void tweede_lesuur_GES()
        {
            CheckLesuur(2, "GES");
        }

        [Test]
        public void derde_lesuur_FRA()
        {
            CheckLesuur(3, "FRA");
        }

        [Test]
        public void vierde_lesuur_NED()
        {
            CheckLesuur(4, "NED");
        }

        [Test]
        public void vijfde_lesuur_ENG()
        {
            CheckLesuur(5, "ENG");
        }

        [Test]
        public void zesde_lesuur_LO()
        {
            CheckLesuur(6, "LO");
        }

        [Test]
        public void zevende_lesuur_WWK()
        {
            CheckLesuur(7, "WWK");
        }
    }

    public class DagFactoryDinsdagTests : DagFactoryTests
    {
        private readonly DateTime dinsdag = 21.September(2010);

        protected override IDag CreateDag()
        {
             return DagFactory.CreateDag(dinsdag);
        }

        [Test]
        public void eerste_lesuur_WIS()
        {
            CheckLesuur(1, "WIS");
        }

        [Test]
        public void tweede_lesuur_GOD()
        {
            CheckLesuur(2, "GOD");
        }

        [Test]
        public void derde_lesuur_FRA()
        {
            CheckLesuur(3, "FRA");
        }

        [Test]
        public void vierde_lesuur_NED()
        {
            CheckLesuur(4, "NED");
        }

        [Test]
        public void vijfde_lesuur_ENG()
        {
            CheckLesuur(5, "ENG");
        }

        [Test]
        public void zesde_lesuur_SEI()
        {
            CheckLesuur(6, "SEI");
        }

        [Test]
        public void zevende_lesuur_MO()
        {
            CheckLesuur(7, "MO");
        }
    }

    public class DagFactoryWoensdagTests : DagFactoryTests
    {
        private readonly DateTime woensdag = 22.September(2010);

        protected override IDag CreateDag()
        {
             return DagFactory.CreateDag(woensdag);
        }

        [Test]
        public void eerste_lesuur_AAR()
        {
            CheckLesuur(1, "AAR");
        }

        [Test]
        public void tweede_lesuur_FRA()
        {
            CheckLesuur(2, "FRA");
        }

        [Test]
        public void derde_lesuur_GES()
        {
            CheckLesuur(3, "GES");
        }

        [Test]
        public void vierde_lesuur_WIS()
        {
            CheckLesuur(4, "WIS");
        }

        [Test]
        public void geen_namiddag()
        {
            Assert.That(dag.Vakken.Count(), Is.EqualTo(4));
        }
    }

    public class DagFactoryDonderdagTests : DagFactoryTests
    {
        private readonly DateTime donderdag = 23.September(2010);

        protected override IDag CreateDag()
        {
            return DagFactory.CreateDag(donderdag);
        }

        [Test]
        public void eerste_lesuur_GOD()
        {
            CheckLesuur(1, "GOD");
        }

        [Test]
        public void tweede_lesuur_SOAC()
        {
            CheckLesuur(2, "SOAC");
        }

        [Test]
        public void derde_lesuur_WIS()
        {
            CheckLesuur(3, "WIS");
        }

        [Test]
        public void vierde_lesuur_BIO()
        {
            CheckLesuur(4, "BIO");
        }

        [Test]
        public void vijfde_lesuur_WWK()
        {
            CheckLesuur(5, "WWK");
        }

        [Test]
        public void zesde_lesuur_WWK()
        {
            CheckLesuur(6, "WWK");
        }

        [Test]
        public void zevende_lesuur_SEI()
        {
            CheckLesuur(7, "SEI");
        }
    }

    public class DagFactoryVrijdagTests : DagFactoryTests
    {
        private readonly DateTime vrijdag = 24.September(2010);

        protected override IDag CreateDag()
        {
            return DagFactory.CreateDag(vrijdag);
        }

        [Test]
        public void eerste_lesuur_LO()
        {
            CheckLesuur(1, "LO");
        }

        [Test]
        public void tweede_lesuur_WIS()
        {
            CheckLesuur(2, "WIS");
        }

        [Test]
        public void derde_lesuur_TO()
        {
            CheckLesuur(3, "TO");
        }

        [Test]
        public void vierde_lesuur_TO()
        {
            CheckLesuur(4, "TO");
        }

        [Test]
        public void vijfde_lesuur_NED()
        {
            CheckLesuur(5, "NED");
        }

        [Test]
        public void zesde_lesuur_NED()
        {
            CheckLesuur(6, "NED");
        }

        [Test]
        public void zevende_lesuur_FRA()
        {
            CheckLesuur(7, "FRA");
        }
    }

}