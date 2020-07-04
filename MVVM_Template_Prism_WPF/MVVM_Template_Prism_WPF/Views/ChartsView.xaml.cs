using LiveCharts;
using LiveCharts.Wpf;
using MVVM_Template_Prism_WPF.Models;
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

namespace MVVM_Template_Prism_WPF.Views
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ChartsView()
        {
            InitializeComponent();

            /*SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");*/

            var List = RegistroNacional.Instance.ListaCiudades;

            SeriesCollection = new SeriesCollection();
            Labels = new string[List.Count];


            ColumnSeries columnSeries = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };

            Formatter = value => value.ToString("N");

            int i = 0;
            foreach (var x in List)
            {
                columnSeries.Values.Add(x.Habitantes.Count);
                Labels[i] = x.Nombre;
                i++;
            }

            i = 0;

            SeriesCollection.Add(columnSeries);

            //MyCartesianChart.Series.Add(columnSeries);


            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var List = RegistroNacional.Instance.ListaCiudades;

            Labels = new string[List.Count];


            ColumnSeries columnSeries = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };

            Formatter = value => value.ToString("N");

            int i = 0;
            foreach (var x in List)
            {
                columnSeries.Values.Add(x.Habitantes.Count);
                Labels[i] = x.Nombre;
                i++;
            }

            i = 0;

            SeriesCollection.Clear();
            SeriesCollection.Add(columnSeries);

            //MyCartesianChart.Series.Add(columnSeries);
            /*MyCartesianChart.AxisX.Add(axisX);
            MyCartesianChart.AxisY.Add(new Axis
            {
                LabelFormatter = value =>value.ToString(),
                Separator = new LiveCharts.Wpf.Separator()
            });*/

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//ESTA GRAFICA MUESTRA LA SUMA DE LOS SUELDOS DE LAS PERSONAS DE LIMA, TUMBES
         //MyCartesianChart = null;
            var List = RegistroNacional.Instance.ListaCiudades;

            Labels = new string[List.Count];


            ColumnSeries columnSeries = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<double>(),
                LabelPoint = point => point.Y.ToString()
            };

            Formatter = value => value.ToString("N");

            int i = 0;
            foreach (var x in List)
            {
                double Suma = 0;
                foreach (var y in x.Habitantes)
                {
                    Suma += y.Sueldo;
                }

                columnSeries.Values.Add(Suma);
                Labels[i] = x.Nombre;
                i++;
            }

            i = 0;

            SeriesCollection.Clear();
            SeriesCollection.Add(columnSeries);

        }
    }
}
