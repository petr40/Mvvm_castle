using System;
namespace Mvvm_Castle.EventAggregator
{
    public interface IEventAggregator
    {
        void AddListener(object listener);
        void RaiseEvent<T>(T eventData);
    }
}
