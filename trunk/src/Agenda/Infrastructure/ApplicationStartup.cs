using System;
using Agendas.Entities;
using Agendas.Handlers;
using Agendas.Migrations;
using Agendas.Queries;
using AutoMapper;

namespace Agendas.Infrastructure
{
    internal static class ApplicationStartup
    {
        public static void Run()
        {
            InitializeContainer();
            MigrateToLatestVersion();
            InitializeMapping();
        }

        private static void InitializeMapping()
        {
            Mapper.CreateMap<DateTime, string>()
                .ConvertUsing(d => d.ToLongDateString());
            Mapper.CreateMap<IDay, GetDayResponse>();

            Mapper.AssertConfigurationIsValid();
        }

        private static void InitializeContainer()
        {
            //Poor man's dependency injection
            IocContainer.Register(new GetDayHandler());
            IocContainer.Register(new SaveDayHandler());
        }

        private static void MigrateToLatestVersion()
        {
            var migrator = new Migrator.Migrator(
                "SQLite",
                NHibernateProvider.CreateSession().Connection.ConnectionString,
                typeof (M001_Dag).Assembly
                );
            migrator.MigrateTo(0);
            migrator.MigrateToLastVersion();
        }
    }
}