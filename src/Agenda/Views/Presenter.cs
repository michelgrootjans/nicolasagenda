using System;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public abstract class Presenter : IDisposable
    {
        protected Presenter()
        {
            IocContainer.Register(this);
        }

        public virtual void Dispose()
        {
            IocContainer.Unregister(this);
        }
    }
}