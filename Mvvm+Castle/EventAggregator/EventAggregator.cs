using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using Castle.Core;
using System.Threading;

namespace Mvvm_Castle.EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        private readonly IKernel _kernel;
        private IList<object> _listeners;
        private SynchronizationContext _context;

        public EventAggregator(IKernel kernel, SynchronizationContext context)
        {
            _kernel = kernel;
            _context = context;
            _listeners = new List<object>();
        }

        public void AddListener(object listener)
        {
            _listeners.Add(listener);
        }

        public void RaiseEvent<T>( T eventData)
        {
            foreach (var l in _listeners)
            {
                IListener<T> listener = l as IListener<T>;
                if (listener != null)
                    _context.Post(delegate { listener.Handle(eventData); }, null);
            }
        }    
    }
}
