using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvvm_Castle.EventAggregator
{
    public interface IListener<T>
    {
        void Handle(T eventData);
    }
}
