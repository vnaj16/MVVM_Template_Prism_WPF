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
    /// Interaction logic for EliminarTelefonoView.xaml
    /// </summary>
    public partial class EliminarTelefonoView : Window
    {
        public Models.Persona persona;

        public EliminarTelefonoView(Models.Persona persona)
        {
            this.persona = persona;
            InitializeComponent();

            ComboBox_Telefonos.ItemsSource = persona.Telefonos;
            ComboBox_Telefonos.SelectedIndex = 0;
            ComboBox_Telefonos.DisplayMemberPath = "Numero";
            TextBlock_Nombre.Text = persona.Nombre;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            persona.Telefonos.Remove(ComboBox_Telefonos.SelectedItem as Models.Telefono);

            MessageBox.Show("Telefono Eliminado");
            this.Close();
        }

        private void Button_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
