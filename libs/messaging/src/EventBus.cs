namespace Harbor.Messaging;

public interface IEventBus
{
    Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken);
}
