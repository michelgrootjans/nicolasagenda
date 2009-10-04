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
        protected readonly DateTime vijfOktober = 5.Oktober(2009);
        private const string AGENDA_DIR = "Agenda";
        protected const string PATH = AGENDA_DIR + "\\2009_10_05";

        protected override void Arrange()
        {
            if (!Directory.Exists(AGENDA_DIR))
            {
                Directory.CreateDirectory(AGENDA_DIR);
                return;
            }
            foreach(var file in Directory.GetFiles(AGENDA_DIR))
                File.Delete(file);
        }

        protected override IAgendaService CreateSystemUnderTest()
        {
            return new AgendaService();
        }
    }

    public class when_file_doesnt_exist : AgendaTest
    {
        [Test]
        public void should_get_an_empty_day()
        {
            var agenda = sut.GetContentFor(vijfOktober);
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

            sut.Save(courses, vijfOktober);

            File.Exists(PATH).ShouldBeTrue();
        }
    }

    public class when_file_exists_with_one_course : AgendaTest
    {
        private List<ICourse> courses;
        private IList<ICourse> agenda;

        protected override void Arrange()
        {
            base.Arrange();
            courses = new List<ICourse> {new Course(2, "FRA", "les geleerd")};
            CreateSystemUnderTest().Save(courses, vijfOktober);
        }

        protected override void Act()
        {
            agenda = sut.GetContentFor(vijfOktober);
        }

        [Test]
        public void should_have_only_one_course()
        {
            agenda.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_have_the_right_content()
        {
            var course = agenda[0];
            course.Uur.ShouldBeEqualTo(2);
            course.Vak.ShouldBeEqualTo("FRA");
            course.Inhoud.ShouldBeEqualTo("les geleerd");
        }
    }
}