using System;
using Mvvm_Castle.ViewModels;
namespace Mvvm_Castle.AppController
{
    public interface IAppController
    {
        void Execute<T>(T commandData);
        IWorkspace GetWorkspace();
    }
}
