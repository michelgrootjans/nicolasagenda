using Agendas.Entities;
using Agendas.Handlers;
using Agendas.Queries;
using AutoMapper;
using Configuration = NHibernate.Cfg.Configuration;

namespace Agendas.Infrastructure
{
    internal static class ApplicationStartup
    {
        public static void Run()
        {
            InitializeContainer();
            InitializeOrm();
            InitializeMapping();
        }

        private static void InitializeMapping()
        {
            Mapper.CreateMap<IDag, GetDayResult>();

            Mapper.AssertConfigurationIsValid();
        }

        private static void InitializeContainer()
        {
            //Poor man's dependency injection
            IocContainer.Register(new GetDayHandler());
        }

        private static void InitializeOrm()
        {
            NHibernateSessionProvider.Initialize(
                new Configuration().Configure().BuildSessionFactory(),
                new StaticStateStore()
                );
        }
    }
}