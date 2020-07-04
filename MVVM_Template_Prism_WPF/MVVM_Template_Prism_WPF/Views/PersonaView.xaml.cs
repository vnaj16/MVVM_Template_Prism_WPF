﻿using System;
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
using MVVM_Template_Prism_WPF.ViewModels;

namespace MVVM_Template_Prism_WPF.Views
{
    /// <summary>
    /// Interaction logic for PersonaView.xaml
    /// </summary>
    public partial class PersonaView : UserControl
    {
        public PersonaView()
        {
            InitializeComponent();
            this.DataContext = PersonaViewModel.Instance;
        }
    }
}
