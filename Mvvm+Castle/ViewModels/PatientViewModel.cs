using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Mvvm_Castle.AppController;
using System.Windows.Media;
using System.ComponentModel;


namespace Mvvm_Castle.ViewModels
{
    public class PatientViewModel : IWorkspace, INotifyPropertyChanged
    {
        private readonly IAppController _appController;

        public ICommand CloseWorkspace { get; set; }
        public ICommand ChangeBackground { get; set; }

        private SolidColorBrush bck;
        public SolidColorBrush BackColor { get { return bck; } set {

            if (bck != value)
            {
                bck = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BackColor"));
            }
        } }


        public string TabTitle { get; set; }

        public PatientViewModel(IAppController appController)
        {
            _appController = appController;
            TabTitle = "Patient";

            CloseWorkspace = new RelayCommand(param => { 
                CloseView(this, EventArgs.Empty); 
            });

            ChangeBackground = new RelayCommand(param =>
            {
                BackColor= new SolidColorBrush(Color.FromRgb(255, 255, 0));
            });

        }

        #region IWorkspace Members

        public EventHandler CloseView { get; set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
