using System;

namespace CptLost.EventBus
{
    public class EventBusReceiver<T> : IEventBusReceiver<T> where T : IBusEvent
    {
        public Action<T> OnEvent { get; set; } = delegate(T busEvent) { };
        public Action OnEventNoArgs { get; set; } = delegate { };

        public EventBusReceiver(Action<T> onEvent)
        {
            OnEvent = onEvent;
        }

        public EventBusReceiver(Action onEventNoArgs)
        {
            OnEventNoArgs = onEventNoArgs;
        }

        public static implicit operator EventBusReceiver<T>(Action onEventNoArgs)
        {
            return new EventBusReceiver<T>(onEventNoArgs);
        }

        public static implicit operator EventBusReceiver<T>(Action<T> onEvent)
        {
            return new EventBusReceiver<T>(onEvent);
        }

        public void Add(Action<T> onEvent)
        {
            OnEvent += onEvent;
        }

        public void Remove(Action<T> onEvent)
        {
            OnEvent -= onEvent;
        }

        public void Add(Action onEvent)
        {
            OnEventNoArgs += onEvent;
        }

        public void Remove(Action onEvent)
        {
            OnEventNoArgs -= onEvent;
        }

        public void Invoke(T busEvent)
        {
            OnEventNoArgs.Invoke();
            OnEvent.Invoke(busEvent);
        }
    }
}