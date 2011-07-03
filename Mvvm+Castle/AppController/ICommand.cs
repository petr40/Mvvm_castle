using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Mvvm_Castle.AppController
{
    public interface ICommand<T> : ICommand
    {
        void Execute(T commandData);
    }
}
