using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvvm_Castle.Repositories;
using Mvvm_Castle.AppController;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Mvvm_Castle.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IAppController _appController;
        private readonly IPatientRepository _patientRepository;

        private ObservableCollection<IWorkspace> _workspaces;
        public  ICollectionView Workspaces { get; set; }
        public ICommand AddWorkspace { get; set; }

        public MainWindowViewModel(IAppController appController, IPatientRepository patientRepository)
        {
            _appController = appController;
            _patientRepository = patientRepository;

            AddWorkspace = new RelayCommand(param =>
            {

                var ws = _appController.GetWorkspace();             
                ws.CloseView += OnWorkspaceClose;
                _workspaces.Add(ws);
            });
            
            _workspaces = new ObservableCollection<IWorkspace>();

            Workspaces = CollectionViewSource.GetDefaultView(_workspaces);
        }

        private void OnWorkspaceClose(object sender, EventArgs e)
        {
            _workspaces.Remove((IWorkspace)sender);
        }


    }
}
