using NUnit.Framework;

namespace Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShouldBeInstanceOf<T>(this object actual)
        {
            Assert.IsInstanceOf(typeof(T), actual);
            return (T) actual;
        }

        public static T ShouldBeEqualTo<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }

        public static void ShouldBeNull(this object actual)
        {
            Assert.IsNull(actual);
        }
    }
}