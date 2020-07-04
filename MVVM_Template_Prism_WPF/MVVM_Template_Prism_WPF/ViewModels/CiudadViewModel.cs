using MVVM_Template_Prism_WPF.Helpers;
using MVVM_Template_Prism_WPF.Models;
using MVVM_Template_Prism_WPF.Views.Ciudad;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Template_Prism_WPF.ViewModels
{
    public class CiudadViewModel : BindableBase
    {

        private static CiudadViewModel instance = null;

        private CiudadViewModel()
        {
            listaCiudades = RegistroNacional.Instance.ListaCiudades;

            VerInfoCommand = new DelegateCommand(Execute_VerInfoCommand, CanExecute_VerInfoCommand).ObservesProperty(() => CurrentCiudad);
            DeleteCommand = new DelegateCommand(Execute_DeleteCommand, CanExecute_DeleteCommand).ObservesProperty(() => CurrentCiudad);
            AgregarCommand = new DelegateCommand(Execute_AgregarCommand);
            ActualizarCommand = new DelegateCommand(Execute_ActualizarCommand, CanExecute_ActualizarCommand).ObservesProperty(() => CurrentCiudad);


        }
        public static CiudadViewModel Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new CiudadViewModel();
                }
                return instance;
            }
        }


        private Ciudad currentCiudad;

        public Ciudad CurrentCiudad
        {
            get { return currentCiudad; }
            set { SetProperty(ref currentCiudad, value); }
        }

        private ObservableCollection<Ciudad> listaCiudades;

        public ObservableCollection<Ciudad> ListaCiudades
        {
            get { return listaCiudades; }
            set { SetProperty(ref listaCiudades, value); }
        }


        #region
        public ICommand DeleteCommand { get; set; }

        private bool CanExecute_DeleteCommand()
        {
            return !(CurrentCiudad is null);
        }

        private void Execute_DeleteCommand()
        {
            foreach(var x in CurrentCiudad.Habitantes)
            {
                x.Ciudad = null;
            }

            ListaCiudades.Remove(CurrentCiudad);


            CurrentCiudad = null;
        }


        public ICommand VerInfoCommand { get; set; }

        private bool CanExecute_VerInfoCommand()
        {
            return !(CurrentCiudad is null);
        }

        private void Execute_VerInfoCommand()
        {
            MessageBox.Show(CurrentCiudad.ToString());
        }

        public ICommand AgregarCommand { get; set; }

        private void Execute_AgregarCommand()
        {
            RegistrarCiudadView registrarCiudadView = new RegistrarCiudadView(Instance);
            registrarCiudadView.ShowDialog();
            if (registrarCiudadView.isRegistered)
            {
                listaCiudades.Add(registrarCiudadView.GetCiudad());
            }

            //MessageBox.Show("Agregar persona View");
        }

        public ICommand ActualizarCommand { get; set; }

        private void Execute_ActualizarCommand()
        {
            RegistrarCiudadView registrarCiudadView = new RegistrarCiudadView(Instance, true, CurrentCiudad);
            registrarCiudadView.ShowDialog();
        }

        private bool CanExecute_ActualizarCommand()
        {
            return !(CurrentCiudad is null);
        }

        #endregion
    }
}
