using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<object>> subsrciptions = new Dictionary<Type, List<object>>();

        public void Publish<T>(T message) where T : IApplicationEvent
        {
            lock (subsrciptions)
            {
                List<object> subscribers;
                if (subsrciptions.TryGetValue(typeof(T), out subscribers))
                {
                    // To Array creates a copy in case someone unsubscribes in their own handler
                    foreach (var subscriber in subscribers.ToArray())
                    {
                        ((Action<T>)subscriber)(message);
                    }
                }
            }

        }

        public void Subscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            lock (subsrciptions)
            {
                List<object> subscribers;
                if (!subsrciptions.TryGetValue(typeof(T), out subscribers))
                {
                    subscribers = new List<object>();
                    subsrciptions.Add(typeof(T), subscribers);
                }
                subscribers.Add(action);
            }

        }

        public void Unsubscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            lock (subsrciptions)
            {
                List<object> subscribers;
                if (subsrciptions.TryGetValue(typeof(T), out subscribers))
                {
                    subscribers.Remove(action);
                }
            }
        }

        public void Dispose()
        {
            lock (subsrciptions)
            {
                subsrciptions.Clear();
            }
        }
    }
}
