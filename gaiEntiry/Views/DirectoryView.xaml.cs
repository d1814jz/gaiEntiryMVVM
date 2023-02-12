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

namespace gaiEntiry.Views
{

    public partial class DirectoryView : Window
    {
        gaiEngEntities db = new gaiEngEntities();


        private string tableName { get; set; }
        public DirectoryView(string tableName)
        {

            DirectoryView_Load();
        }
        public DirectoryView()
        {
            InitializeComponent();
            this.tableName = tableName;

        }

        public void DirectoryView_Load()
        {
            MessageBox.Show(tableName);
            InitializeComponent();
            getDate(tableName);
        }

        public void getDate(string tableName)
        {
            List<string> directoryTablesList = new List<string>() { "Auto", "Driver", "IllegalType", "Rank" };
            switch (tableName) {
                case "Auto":
                    dataGridView1.ItemsSource = db.Auto.ToList();
                    break;
                case "Driver":
                    dataGridView1.ItemsSource = db.Driver.ToList();
                    break;
                case "IllegalType":
                    dataGridView1.ItemsSource = db.IllegalType.ToList();
                    break;
                case "Rank":
                    dataGridView1.ItemsSource = db.Rank.ToList();
                    break;
            }


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGridView_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox1_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}