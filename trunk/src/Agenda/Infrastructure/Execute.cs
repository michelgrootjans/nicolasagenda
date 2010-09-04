namespace Agendas.Infrastructure
{

    public static class Execute
    {
        public static TResult Query<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery<TResult>
            where TResult : IEvent
        {
            var handler = IocContainer.GetImplementationOf<IQueryHandler<TQuery, TResult>>();
            var result = handler.Handle(query);
            BroadCast(result);
            return result;
        }

        private static void BroadCast<T>(T domainEvent) where T : IEvent
        {
            var handlers = IocContainer.GetImplementationsOf<IEventHandler<T>>();
            foreach (var handler in handlers)
            {
                handler.HandleEvent(domainEvent);
            }
        }
    }
}