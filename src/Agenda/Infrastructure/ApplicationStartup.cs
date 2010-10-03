using Agendas.Entities;
using Agendas.Migrations;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

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
            InitializeIoCContainer();
            hasBeenInitialized = true;
        }

        private static void InitializeORM()
        {
            using (new TraceLogger("Initializing ORM"))
            {
                var sessionFactory = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.UsingFile("agenda.db"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Dag>())
                    .BuildConfiguration()
                    .BuildSessionFactory();
                NHibernateProvider.Initialize(sessionFactory);
            }
        }

        private static void MigrateToLatestVersion()
        {
            using (var logger = new TraceLogger("Migrating the current database"))
            {
                using (var session = NHibernateProvider.CreateSession())
                {
                    var migrator = new Migrator.Migrator("SQLite", session.Connection.ConnectionString,
                                                         typeof (M001_Dag).Assembly);
                    migrator.Logger = logger;
                    migrator.MigrateToLastVersion();
                }
            }
        }

        private static void InitializeIoCContainer()
        {
            //var repository = new NhibernateRepository();
        }
    }
}