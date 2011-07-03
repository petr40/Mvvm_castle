using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvvm_Castle.ViewModels
{
    public interface IWorkspace
    {
       EventHandler CloseView { get; set; }
    }
}
