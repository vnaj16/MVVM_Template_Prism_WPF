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

namespace MVVM_Template_Prism_WPF.Views.Persona
{
    /// <summary>
    /// Interaction logic for RegistrarTelefonoView.xaml
    /// </summary>
    public partial class RegistrarTelefonoView : Window
    {
        public Models.Persona persona;
        public string Numero;
        public RegistrarTelefonoView(Models.Persona persona)
        {
            this.persona = persona;
            this.DataContext = Numero;
            InitializeComponent();
            TextBlock_Nombre.Text = persona.Nombre + " " + persona.Apellido;
        }

        //Button Registrar
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Numero = TextBox_Numero.Text;
            if (!String.IsNullOrWhiteSpace(Numero))
            {
                Models.Telefono telefono = new Models.Telefono();
                telefono.Numero = Numero;
                telefono.Persona = persona;
                MessageBox.Show("Telefono Registrado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese el numero");
            }
        }

        private void Button_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
