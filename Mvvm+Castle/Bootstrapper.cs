using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Mvvm_Castle.Installers;
using Mvvm_Castle.ViewModels;

namespace Mvvm_Castle
{
    public static class Bootstrapper
    {
        private static IWindsorContainer _container;

        public static void Init()
        {
            _container = new WindsorContainer();
            _container.Install(

                    new ViewModelsInstaller(),
                    new RepositoriesInstaller(),
                    new AppInstaller(),
                    new SynchronizatonInstaller()
                );
        }

        public static void Run()
        {
          var mainWindow = _container.Resolve<MainWindow>();
          var mainViewModel = _container.Resolve<MainWindowViewModel>();

          mainWindow.DataContext = mainViewModel;
          mainWindow.Show();

        }
    }
}
