using System;
using Agendas.Infrastructure;
using NHibernate;

namespace Agendas.Views
{
    public abstract class Presenter : IDisposable
    {
        private ISession session;

        protected ISession Session
        {
            get
            {
                if (session != null) 
                    return session;
                return session = NHibernateProvider.CreateSession();
            }
        }

        public void Dispose()
        {
            SaveIfChanged();
            if(session != null)
                session.Dispose();
        }

        protected abstract void SaveIfChanged();
    }
}