using NHibernate;

namespace Agendas.Infrastructure
{
    public static class NHibernateSessionProvider
    {
        private const string sessionKey = "nhibernate.session.key";
        private static IStateStore stateStore;
        private static ISessionFactory sessionFactory;

        public static void Initialize(ISessionFactory aSessionFactory, IStateStore aStateStore)
        {
            sessionFactory = aSessionFactory;
            stateStore = aStateStore;
        }

        public static ISession GetSession()
        {
            var session = stateStore[sessionKey];
            if (session == null)
            {
                session = sessionFactory.OpenSession();
                stateStore[sessionKey] = session;
            }
            return (ISession) stateStore[sessionKey];
        }
    }

    public interface IStateStore
    {
        object this[string key] { get; set; }
    }
}