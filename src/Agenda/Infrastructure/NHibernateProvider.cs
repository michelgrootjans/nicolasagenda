using System;
using Agendas.Entities;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Agendas.Infrastructure
{
    public static class NHibernateProvider
    {
        private static readonly ISessionFactory sessionFactory;

        static NHibernateProvider()
        {
            var configuration = new Configuration().Configure("hibernate.cfg.xml");
            sessionFactory = Fluently.Configure(configuration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Day>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public static ISession CreateSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}