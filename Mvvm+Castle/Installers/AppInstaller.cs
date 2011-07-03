using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Mvvm_Castle.AppController;
using Mvvm_Castle.EventAggregator;

namespace Mvvm_Castle.Installers
{
    public class AppInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(

                    Component.For<IAppController>().ImplementedBy<AppController.AppController>().LifeStyle.Singleton,
                    Component.For<IEventAggregator>().ImplementedBy<EventAggregator.EventAggregator>().LifeStyle.Singleton
                );
        }

        #endregion
    }
}
