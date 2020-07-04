using MVVM_Template_Prism_WPF.Models;
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
using MVVM_Template_Prism_WPF.Views.Persona;

namespace MVVM_Template_Prism_WPF.ViewModels
{
    public class PersonaViewModel : BindableBase
    {

        private static PersonaViewModel instance = null;

        private PersonaViewModel()
        {
            listaPersonas = RegistroNacional.Instance.ListaPersonas;

            DeleteCommand = new DelegateCommand(Execute_DeleteCommand, CanExecute_DeleteCommand).ObservesProperty(() => CurrentPersona);
            VerInfoCommand = new DelegateCommand(Execute_VerInfoCommand, CanExecute_VerInfoCommand).ObservesProperty(() => CurrentPersona);
            AgregarCommand = new DelegateCommand(Execute_AgregarCommand);
            ActualizarCommand = new DelegateCommand(Execute_ActualizarCommand, CanExecute_ActualizarCommand).ObservesProperty(() => CurrentPersona);
            RegistrarTelefonoCommand = new DelegateCommand(Execute_RegistrarTelefonoCommand, CanExecute_RegistrarTelefonoCommand).ObservesProperty(() => CurrentPersona);
            EliminarTelefonoCommand = new DelegateCommand(Execute_EliminarTelefonoCommand, CanExecute_EliminarTelefonoCommand).ObservesProperty(() => CurrentPersona);

        }
        public static PersonaViewModel Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new PersonaViewModel();
                }
                return instance;
            }
        }



        private Persona currentPersona;

        public Persona CurrentPersona
        {
            get { return currentPersona; }
            set { SetProperty(ref currentPersona, value); }
        }

        private ObservableCollection<Persona> listaPersonas;

        public ObservableCollection<Persona> ListaPersonas
        {
            get { return listaPersonas; }
            set { SetProperty(ref listaPersonas, value); }
        }

        #region

        public ICommand DeleteCommand { get; set; }

        private bool CanExecute_DeleteCommand()
        {
            return !(CurrentPersona is null);
        }

        private void Execute_DeleteCommand()
        {//MORALEJA APRENDIDA: Eliminar primera todas las referencias al objeto actual, para que luego el GB lo recoja
            CurrentPersona.Ciudad.Habitantes.Remove(CurrentPersona);

            ListaPersonas.Remove(CurrentPersona);

            CurrentPersona = null;
        }


        public ICommand VerInfoCommand { get; set; }

        private bool CanExecute_VerInfoCommand()
        {
            return !(CurrentPersona is null);
        }

        private void Execute_VerInfoCommand()
        {
            MessageBox.Show(CurrentPersona.ToString());
        }

        public ICommand AgregarCommand { get; set; }

        private void Execute_AgregarCommand()
        {
            RegistrarPersonaView registrarPersonaView = new RegistrarPersonaView(Instance, RegistroNacional.Instance.ListaCiudades);
            registrarPersonaView.ShowDialog();
            if (registrarPersonaView.isRegistered)
            {
                listaPersonas.Add(registrarPersonaView.GetPersona());
            }

            //MessageBox.Show("Agregar persona View");
        }


        public ICommand ActualizarCommand { get; set; }

        private void Execute_ActualizarCommand()
        {
            RegistrarPersonaView registrarPersonaView = new RegistrarPersonaView(Instance, RegistroNacional.Instance.ListaCiudades, true, CurrentPersona);
            registrarPersonaView.ShowDialog();
        }

        private bool CanExecute_ActualizarCommand()
        {
            return !(CurrentPersona is null);
        }

        public ICommand RegistrarTelefonoCommand { get; set; }

        private void Execute_RegistrarTelefonoCommand()
        {
            RegistrarTelefonoView registrarTelefonoView = new RegistrarTelefonoView(CurrentPersona);
            registrarTelefonoView.ShowDialog();
        }

        private bool CanExecute_RegistrarTelefonoCommand()
        {
            return !(CurrentPersona is null);
        }

        public ICommand EliminarTelefonoCommand { get; set; }

        private void Execute_EliminarTelefonoCommand()
        {
            EliminarTelefonoView eliminarTelefonoView = new EliminarTelefonoView(CurrentPersona);
            eliminarTelefonoView.ShowDialog();
        }

        private bool CanExecute_EliminarTelefonoCommand()
        {
            return !(CurrentPersona is null);
        }


        #endregion
    }
}
