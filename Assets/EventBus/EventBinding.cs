using System;

public class EventBinding<T> : IEventBinding<T> where T : IEvent
{
    Action<T> onEvent = delegate(T _) {};
    Action onEventNoArgs = delegate {};

    Action<T> IEventBinding<T>.OnEvent { get => onEvent; set => onEvent = value; }
    Action IEventBinding<T>.OnEventNoArgs { get => onEventNoArgs; set => onEventNoArgs = value; }

    public EventBinding(Action<T> onEvent) {
        this.onEvent = onEvent;
    }

    public EventBinding(Action onEventNoArgs) {
        this.onEventNoArgs = onEventNoArgs;
    }

    public void Add(Action<T> onEvent) => this.onEvent += onEvent;
    public void Remove(Action<T> onEvent) => this.onEvent -= onEvent;

    public void Add(Action onEventNoArgs) => this.onEventNoArgs += onEventNoArgs;
    public void Remove(Action onEventNoArgs) => this.onEventNoArgs -= onEventNoArgs;
}
