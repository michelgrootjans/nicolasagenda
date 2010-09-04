using NUnit.Framework;

namespace Tests.Extensions
{
    public static class BoolExtensions
    {
        public static void ShouldBeTrue(this bool condition)
        {
            Assert.IsTrue(condition);
        }

        public static void ShouldBeFalse(this bool condition)
        {
            Assert.IsFalse(condition);
        }
    }
}