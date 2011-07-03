using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using System.Windows;
using Castle.Core;
using Mvvm_Castle.EventAggregator;
using Mvvm_Castle.ViewModels;

namespace Mvvm_Castle.AppController
{
    public class AppController : IAppController 
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IKernel _kernel;

        public AppController(IKernel kernel, IEventAggregator eventAggregator)
        {
            _kernel = kernel;
            _eventAggregator = eventAggregator;
            _kernel.ComponentCreated += new ComponentInstanceDelegate(OnComponentCreated);
        }

        public void Execute<T>(T commandData)
        {
            ICommand<T> command = _kernel.Resolve<ICommand<T>>();
            try
            {
                command.Execute(commandData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void OnComponentCreated(ComponentModel model, object component)
        {
            _eventAggregator.AddListener(component);
        }

        public void RaiseEvent<T>(T eventData)
        {
            _eventAggregator.RaiseEvent(eventData);
        }

        public IWorkspace GetWorkspace()
        {
            return _kernel.Resolve<IWorkspace>();
        }
    }
}
