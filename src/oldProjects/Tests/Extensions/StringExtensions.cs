using Agenda.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    public static class StringExtensions
    {
        public static void ShouldBeEmpty(this string actual)
        {
            Assert.IsTrue(actual.IsEmpty(), string.Format("should have been empty, but was '{0}'", actual));
        }
    }
}