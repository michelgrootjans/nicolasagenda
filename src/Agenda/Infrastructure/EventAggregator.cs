namespace Agendas.Infrastructure
{
    internal static class EventAggregator
    {
        public static void Raise<T>(T domainEvent)
        {
            foreach (var handler in IocContainer.GetImplementationsOf<IListenTo<T>>())
                handler.HandleEvent(domainEvent);
        }
    }
}