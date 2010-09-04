using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.TestUtilities
{
    [TestFixture]
    public abstract class StaticContextSpecification
    {
        [SetUp]
        public virtual void SetUp()
        {
            Arrange();
            Act();
        }

        protected virtual void Arrange()
        {
        }

        protected virtual void Act()
        {
        }

        protected T Dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        protected IMockExpectation<T> When<T>(T t) where T : class
        {
            return new MockExpectation<T>(t);
        }
    }
}