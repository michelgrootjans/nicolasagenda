using Agendas.Entities;
using Agendas.Migrations;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace Agendas.Infrastructure
{
    internal static class ApplicationStartup
    {
        private static bool hasBeenInitialized;

        public static void Run()
        {
            if (hasBeenInitialized)
                return;

            InitializeORM();
            MigrateToLatestVersion();
            hasBeenInitialized = true;
        }

        private static void InitializeORM()
        {
            //var configuration = new Configuration();
            //var sessionFactory = Fluently.Configure(configuration)
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Dag>())
            //    .BuildConfiguration()
            //    .BuildSessionFactory();
            var sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("agenda.db"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Dag>())
                .BuildConfiguration()
                .BuildSessionFactory();
            NHibernateProvider.Initialize(sessionFactory);
        }

        private static void MigrateToLatestVersion()
        {
            Migrator.Migrator migrator;
            using (var session = NHibernateProvider.CreateSession())
            {
                migrator = new Migrator.Migrator("SQLite", session.Connection.ConnectionString,
                                                 typeof (M001_Dag).Assembly);
                //migrator.MigrateTo(0);
                migrator.MigrateToLastVersion();
            }
        }
    }
}