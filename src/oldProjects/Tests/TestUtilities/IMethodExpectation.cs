using Rhino.Mocks.Interfaces;

namespace Tests.TestUtilities
{
    public interface IMethodExpectation<T>
    {
        void Return(T t);
    }

    internal class MethodExpectation<T> : IMethodExpectation<T>
    {
        private readonly IMethodOptions<T> options;

        public MethodExpectation(IMethodOptions<T> options)
        {
            this.options = options;
        }

        public void Return(T t)
        {
            options.Return(t);
        }
    }
}