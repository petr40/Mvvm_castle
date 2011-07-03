using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Mvvm_Castle.ViewModels;
using System.Threading;
using Mvvm_Castle.Views;

namespace Mvvm_Castle.Installers
{
    public class ViewModelsInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(

                Component.For<MainWindowViewModel>(),
                Component.For<MainWindow>(),

                Component.For<IWorkspace>().ImplementedBy<PatientViewModel>().LifeStyle.Transient
              

                );
        }

        #endregion
    }
}
