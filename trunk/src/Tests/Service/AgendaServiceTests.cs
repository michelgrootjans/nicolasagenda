using System;
using System.Collections.Generic;
using System.IO;
using Agenda.Extensions;
using Agenda.Presentation;
using Agenda.Service;
using NUnit.Framework;
using Tests.Extensions;
using Tests.TestUtilities;

namespace Tests.Service
{
    [TestFixture]
    public abstract class AgendaTest : InstanceContextSpecification<IAgendaService>
    {
        protected readonly DateTime drieOktober = 3.Oktober(2009);
        private const string AGENDA_DIR = "Agenda";
        protected const string PATH = AGENDA_DIR + "\\2009_10_03";

        protected override IAgendaService CreateSystemUnderTest()
        {
            return new AgendaService();
        }
    }

    public class when_day_doesnt_exist : AgendaTest
    {
        protected override void Arrange()
        {
            if (Directory.Exists(PATH))
                Directory.Delete(PATH);
        }

        [Test]
        public void should_get_an_empty_day()
        {
            var agenda = sut.GetContentFor(drieOktober);
            agenda.Count.ShouldBeEqualTo(7);
            var uur = 0;
            foreach (var course in agenda)
            {
                course.Uur.ShouldBeEqualTo(uur++);
                course.Vak.ShouldBeEmpty();
                course.Inhoud.ShouldBeEmpty();
            }
        }

        [Test]
        public void should_create_a_new_file()
        {
            var courses = new List<ICourse> {new Course(2, "FRA", "les geleerd")};
            File.Exists(PATH).ShouldBeFalse();

            sut.Save(courses, drieOktober);

            File.Exists(PATH).ShouldBeTrue();
        }
    }

    public class when_file_exists : AgendaTest
    {
        private List<ICourse> courses;

        protected override void Arrange()
        {
            courses = new List<ICourse> {new Course(2, "FRA", "les geleerd")};
        }

        protected override void Act()
        {
            sut.Save(courses, drieOktober);
        }

        [Test]
        public void should_creat_a_new_day()
        {
            var agenda = sut.GetContentFor(3.Oktober(2009));
            agenda.Count.ShouldBeEqualTo(1);
            var course = agenda[0];
            course.Uur.ShouldBeEqualTo(2);
            course.Vak.ShouldBeEqualTo("FRA");
            course.Inhoud.ShouldBeEqualTo("les geleerd");
        }
    }
}