namespace Agendas.Infrastructure
{
    public interface IEvent
    {
    }

    internal interface IListenTo<TEvent> where TEvent : IEvent
    {
        void HandleEvent(TEvent domainEvent);
    }
}