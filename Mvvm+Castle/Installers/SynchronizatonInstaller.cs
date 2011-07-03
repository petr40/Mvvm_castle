using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using System.Threading;
using System.Windows.Threading;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Mvvm_Castle.Installers
{
    public class SynchronizatonInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(Castle.Windsor.IWindsorContainer container,IConfigurationStore store)
        {
            container.Register(

                Component.For<SynchronizationContext>().UsingFactoryMethod(()=>
                    
                    {
                        if(SynchronizationContext.Current == null)
                        {
                            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext());
                        }

                        return SynchronizationContext.Current;

                    }).LifeStyle.Singleton

                );
        }

        #endregion
    }
}
