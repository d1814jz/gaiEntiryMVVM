﻿using gaiEntiry.ViewModel;
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

namespace gaiEntiry.View
{
    /// <summary>
    /// Interaction logic for DriverView.xaml
    /// </summary>
    public partial class DriverView : Window
    {
        public DriverView()
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
        }
    }
}
