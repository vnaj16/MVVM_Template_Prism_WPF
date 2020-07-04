using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MVVM_Template_Prism_WPF.ViewModels;
using MVVM_Template_Prism_WPF.Models;
using MVVM_Template_Prism_WPF.Helpers;

namespace MVVM_Template_Prism_WPF.Views.Persona
{
    /// <summary>
    /// Interaction logic for RegistrarPersonaView.xaml
    /// </summary>
    public partial class RegistrarPersonaView : Window
    {
        private PersonaViewModel personaViewModel;
        private Models.Persona newPersona;
        private Models.Persona copyPersona_Updated;
        public bool isRegistered = false;
        private bool isUpdate = false;
        public string ButtonState = "Registrar";

        public RegistrarPersonaView(PersonaViewModel personaViewModel, IEnumerable<Models.Ciudad> ciudades, bool isUpdate = false, Models.Persona obj = null)
        {
            InitializeComponent();
            this.personaViewModel = personaViewModel;
            if (!isUpdate)
            {
                newPersona = new Models.Persona();
            }
            else
            {
                newPersona = obj;
                copyPersona_Updated = obj.Clone();
                ButtonState = "Actualizar";
            }

            Button_Registrar.Content = ButtonState;
            this.DataContext = newPersona;
            ComboBox_Ciudades.ItemsSource = ciudades;
            this.isUpdate = isUpdate;
        }

        public Models.Persona GetPersona()
        {
            if (!(newPersona is null) && isRegistered)
            {
                return newPersona;
            }

            return null;
        }

        private void Button_Registrar_Click(object sender, RoutedEventArgs e)
        {
            var MyTuple = MyValidator.TryValidateObject(newPersona);
            if (MyTuple.Item1)
            {
                if (!isUpdate)
                {
                    isRegistered = true;
                    MessageBox.Show($"{newPersona.Nombre} registrado");
                }
                else
                {
                    MessageBox.Show($"{newPersona.Nombre} actualizado");
                }
                this.Close();
            }
            else
            {
                string Messages = "";
                foreach (var x in MyTuple.Item2)
                {
                    Messages += x.ErrorMessage + "\n";
                }

                MessageBox.Show(Messages);
            }
        }

        private void Button_Regresar_Click(object sender, RoutedEventArgs e)
        {
            if (isUpdate)
            {
                newPersona.Ciudad = copyPersona_Updated.Ciudad;
            }
            this.Close();
        }
    }
}
