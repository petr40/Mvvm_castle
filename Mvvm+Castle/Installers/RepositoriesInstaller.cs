using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Mvvm_Castle.Repositories;

namespace Mvvm_Castle.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(

                Component.For<IPatientRepository>().ImplementedBy<PatientRepository>()

                );
        }

        #endregion
    }
}
