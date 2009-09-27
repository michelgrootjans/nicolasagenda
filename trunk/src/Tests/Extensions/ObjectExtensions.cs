using NUnit.Framework;

namespace Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShouldBeInstanceOf<T>(this object target)
        {
            Assert.IsInstanceOfType(typeof(T), target);
            return (T) target;
        }
    }
}