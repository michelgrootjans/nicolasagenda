using System;
using Agenda.Service;
using NUnit.Framework;
using Tests.Extensions;
using Tests.TestUtilities;
using Agenda.Extensions;

namespace Tests.Service
{
    public class ScheduleServiceTest : InstanceContextSpecification<IScheduleService>
    {
        protected override IScheduleService CreateSystemUnderTest()
        {
            return new ScheduleService();
        }
    }

    public class when_asking_on_a_monday : ScheduleServiceTest
    {
        private DateTime vandaag = 28.September(2009);

        [Test]
        public void before_first_hour_should_not_return_anything()
        {
            sut.SchoolIsOngoingOn(vandaag.At(1, 00)).ShouldBeFalse();
            sut.CurrentCourseAt(vandaag.At(1, 00)).ShouldBeEqualTo("");
            sut.CurrentCourseAt(vandaag.At(8, 24)).ShouldBeEqualTo("");
        }

        [Test]
        public void first_hour_should_return_SOAC()
        {
            sut.SchoolIsOngoingOn(vandaag.At(8, 25)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(8, 25)).ShouldBeEqualTo("SOAC");
            sut.CurrentCourseAt(vandaag.At(9, 14)).ShouldBeEqualTo("SOAC");
        }

        [Test]
        public void second_hour_should_return_FRA()
        {
            sut.SchoolIsOngoingOn(vandaag.At(9, 15)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(9, 15)).ShouldBeEqualTo("FRA");
            sut.CurrentCourseAt(vandaag.At(10, 19)).ShouldBeEqualTo("FRA");
        }

        [Test]
        public void third_hour_should_return_BIO()
        {
            sut.SchoolIsOngoingOn(vandaag.At(10, 20)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(10, 20)).ShouldBeEqualTo("BIO");
            sut.CurrentCourseAt(vandaag.At(11, 09)).ShouldBeEqualTo("BIO");
        }

        [Test]
        public void fourth_hour_should_return_FRA()
        {
            sut.SchoolIsOngoingOn(vandaag.At(11, 10)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(11, 10)).ShouldBeEqualTo("FRA");
            sut.CurrentCourseAt(vandaag.At(12, 54)).ShouldBeEqualTo("FRA");
        }

        [Test]
        public void fifth_hour_should_return_PO()
        {
            sut.SchoolIsOngoingOn(vandaag.At(12, 55)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(12, 55)).ShouldBeEqualTo("PO");
            sut.CurrentCourseAt(vandaag.At(13, 44)).ShouldBeEqualTo("PO");
        }

        [Test]
        public void sixth_hour_should_return_PO()
        {
            sut.SchoolIsOngoingOn(vandaag.At(13, 45)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(13, 45)).ShouldBeEqualTo("PO");
            sut.CurrentCourseAt(vandaag.At(14, 49)).ShouldBeEqualTo("PO");
        }

        [Test]
        public void seventh_hour_should_return_NED()
        {
            sut.SchoolIsOngoingOn(vandaag.At(14, 50)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(14, 50)).ShouldBeEqualTo("NED");
            sut.CurrentCourseAt(vandaag.At(15, 39)).ShouldBeEqualTo("NED");
        }

        [Test]
        public void after_seventh_hour_should_not_return_anything()
        {
            sut.SchoolIsOngoingOn(vandaag.At(16, 00)).ShouldBeFalse();
            sut.CurrentCourseAt(vandaag.At(16, 00)).ShouldBeEqualTo("");
            sut.CurrentCourseAt(vandaag.At(23, 59)).ShouldBeEqualTo("");
        }
    }

    public class when_asking_on_a_tuesday : ScheduleServiceTest
    {
        private DateTime vandaag = 29.September(2009);

        [Test]
        public void before_first_hour_should_not_return_anything()
        {
            sut.SchoolIsOngoingOn(vandaag.At(1, 00)).ShouldBeFalse();
            sut.CurrentCourseAt(vandaag.At(1, 00)).ShouldBeEqualTo("");
            sut.CurrentCourseAt(vandaag.At(8, 24)).ShouldBeEqualTo("");
        }
         [Test]
        public void first_hour_should_return_NED()
        {
            sut.SchoolIsOngoingOn(vandaag.At(8, 25)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(8, 25)).ShouldBeEqualTo("NED");
            sut.CurrentCourseAt(vandaag.At(9, 14)).ShouldBeEqualTo("NED");
        }

        [Test]
        public void second_hour_should_return_GOD()
        {
            sut.SchoolIsOngoingOn(vandaag.At(9, 15)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(9, 15)).ShouldBeEqualTo("GOD");
            sut.CurrentCourseAt(vandaag.At(10, 19)).ShouldBeEqualTo("GOD");
        }

        [Test]
        public void third_hour_should_return_TO()
        {
            sut.SchoolIsOngoingOn(vandaag.At(10, 20)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(10, 20)).ShouldBeEqualTo("TO");
            sut.CurrentCourseAt(vandaag.At(11, 09)).ShouldBeEqualTo("TO");
        }

        [Test]
        public void fourth_hour_should_return_TO()
        {
            sut.SchoolIsOngoingOn(vandaag.At(11, 10)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(11, 10)).ShouldBeEqualTo("TO");
            sut.CurrentCourseAt(vandaag.At(12, 54)).ShouldBeEqualTo("TO");
        }

        [Test]
        public void fifth_hour_should_return_WIS()
        {
            sut.SchoolIsOngoingOn(vandaag.At(12, 55)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(12, 55)).ShouldBeEqualTo("WIS");
            sut.CurrentCourseAt(vandaag.At(13, 44)).ShouldBeEqualTo("WIS");
        }

        [Test]
        public void sixth_hour_should_return_NED()
        {
            sut.SchoolIsOngoingOn(vandaag.At(13, 45)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(13, 45)).ShouldBeEqualTo("NED");
            sut.CurrentCourseAt(vandaag.At(14, 49)).ShouldBeEqualTo("NED");
        }

        [Test]
        public void seventh_hour_should_return_FRA()
        {
            sut.SchoolIsOngoingOn(vandaag.At(14, 50)).ShouldBeTrue();
            sut.CurrentCourseAt(vandaag.At(14, 50)).ShouldBeEqualTo("FRA");
            sut.CurrentCourseAt(vandaag.At(15, 39)).ShouldBeEqualTo("FRA");
        }

        [Test]
        public void after_seventh_hour_should_not_return_anything()
        {
            sut.SchoolIsOngoingOn(vandaag.At(16, 00)).ShouldBeFalse();
            sut.CurrentCourseAt(vandaag.At(16, 00)).ShouldBeEqualTo("");
            sut.CurrentCourseAt(vandaag.At(23, 59)).ShouldBeEqualTo("");
        }
    }
}

/*
 * 8:25
 * 9:15 - 10:05
 * 
 * 10:20
 * 11:10 - 12:00
 * 
 * 12:55
 * 13:45 - 14:35
 * 
 * 14:50
 * 15:40 - 15:40
 * 
 * Ma: SOAC, FRA, BIO, FRA, PO, PO, NED
 * Di: NED, GOD, TO, TO, WIS, NED, FRA
 * Wo: AAR, WIS, GOD, NED
 * Do: FRA, WIS, MO, WIS, FRA, NED, LO
 * Vr: LO, FRA, BIO, NED, GES, AAR, WIS
 * 
 */
