namespace Agendas.Infrastructure
{
    public interface IEvent
    {
    }

    internal interface IEventHandler<T> where T : IEvent
    {
        void HandleEvent(T domainEvent);
    }
}