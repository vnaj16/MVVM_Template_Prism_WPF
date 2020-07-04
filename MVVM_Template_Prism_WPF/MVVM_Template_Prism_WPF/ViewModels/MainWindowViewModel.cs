using MVVM_Template_Prism_WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_Template_Prism_WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        //public static ContentControl contentControl;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            //NavigateCommandL = new DelegateCommand<string>(Execute_NavigateCommandL);
        }

        private void Navigate(string uri)
        {
            regionManager.RequestNavigate("ContentRegion", uri);
        }

        /*public ICommand NavigateCommandL { get; set; }

        private bool CanExecute_NavigateCommandL()
        {
            return true;
        }

        private void Execute_NavigateCommandL(string Uri)
        {
            //MessageBox.Show(Uri);
            contentControl.Content = new PersonaView();
        }*/
    }
}
