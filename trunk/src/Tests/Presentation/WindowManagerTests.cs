using System;
using Agenda.Presentation;
using Agenda.Services;
using NUnit.Framework;
using Rhino.Mocks;
using Tests.Extensions;
using Tests.TestUtilities;

namespace Tests.Presentation
{
    public class WindowManagerTest : InstanceContextSpecification<IWindowManager>
    {
        protected IScheduleService scheduleService;

        protected override void Arrange()
        {
            scheduleService = Dependency<IScheduleService>();
        }

        protected override IWindowManager CreateSystemUnderTest()
        {
            return new WindowManager(scheduleService);
        }
    }

    public class when_lesson_is_ongoing : WindowManagerTest
    {
        protected override void Arrange()
        {
            base.Arrange();
            When(scheduleService).IsToldTo(s => s.LessonIsOngoing).Return(true);
        }

        [Test]
        public void should_return_schoolview()
        {
            sut.GetViewAt(DateTime.Now).ShouldBeInstanceOf<SchoolView>();
        }
    }

    public class when_lesson_is_NOT_ongoing : WindowManagerTest
    {
        protected override void Arrange()
        {
            base.Arrange();
            scheduleService.Stub(s => s.LessonIsOngoing).Return(false);
        }

        [Test]
        public void should_return_homeview()
        {
            sut.GetViewAt(DateTime.Now).ShouldBeInstanceOf<HomeView>();
        }
    }
}