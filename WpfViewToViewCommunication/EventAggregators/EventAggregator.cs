namespace WpfViewToViewCommunication.EventAggregators;

public class EventAggregator
{
    private readonly Dictionary<Type, List<object>> _subscribers = new Dictionary<Type, List<object>>();

    public void Publish<TEvent>(TEvent eventToPublish)
    {
        if (_subscribers.TryGetValue(typeof(TEvent), out List<object>? subscriberList))
        {
            foreach (object subscriber in subscriberList.ToArray())
            {
                (subscriber as Action<TEvent>)?.Invoke(eventToPublish);
            }
        }
    }

    public void Subscribe<TEvent>(Action<TEvent> action)
    {
        if (!_subscribers.ContainsKey(typeof(TEvent)))
        {
            _subscribers[typeof(TEvent)] = new List<object>();
        }
        _subscribers[typeof(TEvent)].Add(action);
    }

    public void Unsubscribe<TEvent>(Action<TEvent> action)
    {
        if (_subscribers.TryGetValue(typeof(TEvent), out List<object>? subscriberList))
        {
            subscriberList.Remove(action);
        }
    }
}
