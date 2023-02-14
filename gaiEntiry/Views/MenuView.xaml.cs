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
using System.Windows.Shapes;
using XamlAnimatedGif;

namespace gaiEntiry.Views
{
    public partial class MenuView : Window
    {
        public string Type;
        public string Login;
        public MenuView()
        {
            Login = "1";
            Type = "1";
        }
        public MenuView(string Login, string Type)
        {
            InitializeComponent();
            this.Type = Type;
            this.Login = Login;
        }



        private void DirectoryClick(string itemName)
        {
            DictionaryView directory = new DictionaryView(itemName);
            directory.Show();
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            DirectoryClick("Auto");
        }

        private void Driver_Click(object sender, RoutedEventArgs e)
        {
            DirectoryClick("Driver");
        }

        private void IllegalType_Click(object sender, RoutedEventArgs e)
        {
            DirectoryClick("IllegalType");
        }

        private void Rank_Click(object sender, RoutedEventArgs e)
        {
            DirectoryClick("Rank");
        }
    }
}
