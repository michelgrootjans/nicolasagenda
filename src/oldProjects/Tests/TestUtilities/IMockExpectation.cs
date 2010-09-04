using Rhino.Mocks;

namespace Tests.TestUtilities
{
    public interface IMockExpectation<T>
    {
        IMethodExpectation<R> IsToldTo<R>(Function<T, R> func);
    }

    internal class MockExpectation<T> : IMockExpectation<T> where T : class
    {
        private readonly T t;

        public MockExpectation(T t)
        {
            this.t = t;
        }

        public IMethodExpectation<R> IsToldTo<R>(Function<T, R> func)
        {
            return new MethodExpectation<R>(t.Stub(func));
        }
    }
}