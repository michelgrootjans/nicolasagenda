namespace Agendas.Infrastructure
{
    public static class Execute
    {
        public static void Request<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IEvent
        {
            var handler = IocContainer.GetImplementationOf<IRequestHandler<TRequest, TResponse>>();
            var response = handler.Handle(request);
            BroadCast(response);
        }

        public static void Command<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handlers = IocContainer.GetImplementationsOf<ICommandHandler<TCommand>>();
            foreach (var handler in handlers)
            {
                handler.Execute(command);
            }
        }

        private static void BroadCast<TEvent>(TEvent domainEvent) where TEvent : IEvent
        {
            var handlers = IocContainer.GetImplementationsOf<IListenTo<TEvent>>();
            foreach (var handler in handlers)
            {
                handler.HandleEvent(domainEvent);
            }
        }
    }
}