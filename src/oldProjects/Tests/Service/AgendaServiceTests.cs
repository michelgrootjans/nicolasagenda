using System;
using System.Collections.Generic;
using System.IO;
using Agenda.Extensions;
using Agenda.Services;
using Agenda.ViewModels;
using NUnit.Framework;
using Tests.Extensions;
using Tests.TestUtilities;

namespace Tests.Service
{
    [TestFixture]
    public abstract class AgendaServiceTest : InstanceContextSpecification<IAgendaService>
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
            foreach (var file in Directory.GetFiles(AGENDA_DIR))
                File.Delete(file);
        }

        protected override IAgendaService CreateSystemUnderTest()
        {
            return new AgendaService();
        }
    }

    public class when_file_doesnt_exist : AgendaServiceTest
    {
        [Test]
        public void should_get_an_empty_day()
        {
            var dag = sut.GetContentFor(vijfOktober);
            dag.Courses.Count.ShouldBeEqualTo(7);
            foreach (var course in dag.Courses)
            {
                course.Vak.ShouldBeEmpty();
                course.Inhoud.ShouldBeEmpty();
            }
        }

        [Test]
        public void should_create_a_new_file()
        {
            File.Exists(PATH).ShouldBeFalse();
            var dag = new Dag();
            sut.Save(dag);

            File.Exists(PATH).ShouldBeTrue();
        }
    }

    public class when_file_exists_with_one_course : AgendaServiceTest
    {
        private Dag dag;

        protected override void Arrange()
        {
            base.Arrange();
            dag = new Dag
                      {
                          Courses = new List<Course> {new Course("FRA", "les geleerd")}
                      };
            CreateSystemUnderTest().Save(dag);
        }

        protected override void Act()
        {
            dag = sut.GetContentFor(vijfOktober);
        }

        [Test]
        public void should_have_only_one_course()
        {
            dag.Courses.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_have_the_right_content()
        {
            var course = dag[0];
            course.Vak.ShouldBeEqualTo("FRA");
            course.Inhoud.ShouldBeEqualTo("les geleerd");
        }
    }
}