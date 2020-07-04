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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Template_Prism_WPF.Views
{
    /// <summary>
    /// Interaction logic for CiudadView.xaml
    /// </summary>
    public partial class CiudadView : UserControl
    {
        public CiudadView()
        {
            InitializeComponent();
            this.DataContext = CiudadViewModel.Instance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartsView chartsView = new ChartsView();
            chartsView.Show();
            //Button_Click1
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ReportsView reportsView = new ReportsView();
            reportsView.Show();
        }
    }
}
