using NHibernate;

namespace Agendas.Infrastructure
{
    public static class NHibernateProvider
    {
        private static ISessionFactory sessionFactory;

        public static void Initialize(ISessionFactory aSessionFactory)
        {
            sessionFactory = aSessionFactory;
        }

        public static ISession CreateSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}