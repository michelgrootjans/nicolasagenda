using Agendas.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Agenda.Tests
{
    [TestFixture]
    [Category("Slow")]
    public abstract class InMemoryDataAccessTest
    {
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        protected ISession session;

        [SetUp]
        public void SetUp()
        {
            if (sessionFactory == null)
            {
                NHibernateProfiler.Initialize();
                configuration = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Dag>())
                    .BuildConfiguration();

                sessionFactory = configuration.BuildSessionFactory();
            }
            session = CreateNewSession();
            session.BeginTransaction();
            PrepareData();
            FlushAndClear();
        }

        protected abstract void PrepareData();

        protected void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        private static ISession CreateNewSession()
        {
            var session = sessionFactory.OpenSession();
            var connection = session.Connection;
            new SchemaExport(configuration).Execute(false, true, false, connection, null);
            return session;
        }

        [TearDown]
        public void TearDown()
        {
            session.Transaction.Rollback();
        }
    }
}