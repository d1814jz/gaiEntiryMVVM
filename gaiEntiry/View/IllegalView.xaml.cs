﻿using gaiEntiry.ViewsModel;
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
    /// Interaction logic for IllegalView.xaml
    /// </summary>
    public partial class IllegalView : Window
    {
        public static ListView AllIllegalsView;
        public IllegalView()
        {
            InitializeComponent();
            ViewAllIllegals = AllIllegalsView;
            DataContext = new IllegalViewModel();
            
        }
    }
}
