using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        public ReportsView()
        {
            InitializeComponent();

            ReportViewerDemo.Reset();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1",RegistroNacional.Instance.ListaCiudades);
            ReportViewerDemo.LocalReport.DataSources.Add(reportDataSource);

            ReportViewerDemo.LocalReport.ReportEmbeddedResource = "MVVM_Template_Prism_WPF.Report1.rdlc";

            ReportViewerDemo.RefreshReport();
        }
    }
}
