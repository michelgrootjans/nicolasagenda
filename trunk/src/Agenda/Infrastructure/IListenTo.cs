namespace Agendas.Infrastructure
{
    internal interface IListenTo<TEvent>
    {
        void HandleEvent(TEvent domainEvent);
    }
}