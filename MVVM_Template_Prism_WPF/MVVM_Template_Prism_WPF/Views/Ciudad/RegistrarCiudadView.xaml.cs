using MVVM_Template_Prism_WPF.Helpers;
using MVVM_Template_Prism_WPF.ViewModels;
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

namespace MVVM_Template_Prism_WPF.Views.Ciudad
{
    /// <summary>
    /// Interaction logic for RegistrarCiudadView.xaml
    /// </summary>
    public partial class RegistrarCiudadView : Window
    {
        private CiudadViewModel ciudadViewModel;
        private Models.Ciudad newCiudad;
        private Models.Ciudad copyCiudad_Updated;
        public bool isRegistered = false;
        private bool isUpdate = false;
        public string ButtonState = "Registrar";

        public RegistrarCiudadView(CiudadViewModel ciudadViewModel, bool isUpdate = false, Models.Ciudad obj = null)
        {
            InitializeComponent();

            this.ciudadViewModel = ciudadViewModel;
            if (!isUpdate)
            {
                newCiudad = new Models.Ciudad();
            }
            else
            {
                newCiudad = obj;
                copyCiudad_Updated = obj.Clone();
                ButtonState = "Actualizar";
            }

            Button_Registrar.Content = ButtonState;
            this.DataContext = newCiudad;
            this.isUpdate = isUpdate;
        }

        private void Button_Registrar_Click(object sender, RoutedEventArgs e)
        {
            var MyTuple = MyValidator.TryValidateObject(newCiudad);
            if (MyTuple.Item1)
            {
                if (!isUpdate)
                {
                    isRegistered = true;
                    MessageBox.Show($"{newCiudad.Nombre} registrado");
                }
                else
                {
                    MessageBox.Show($"{newCiudad.Nombre} actualizado");
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
            this.Close();
        }

        public Models.Ciudad GetCiudad()
        {
            if (!(newCiudad is null) && isRegistered)
            {
                return newCiudad;
            }

            return null;
        }
    }
}
