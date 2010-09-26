using System;
using Agendas.Infrastructure;
using NHibernate;

namespace Agendas.Views
{
    public abstract class Presenter : IDisposable
    {
        protected ISession Session { get; private set; }

        protected Presenter()
        {
            IocContainer.Register(this);
            Session = NHibernateProvider.CreateSession();
        }

        public void Dispose()
        {
            IocContainer.Unregister(this);
            SaveIfChanged();
            if(Session != null)
                Session.Dispose();
        }

        protected abstract void SaveIfChanged();
    }
}