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

namespace gaiEntiry.Views
{
    /// <summary>
    /// Interaction logic for DirectoryView.xaml
    /// </summary>
    public partial class DirectoryView : Window
    {
        public string tableName = string.Empty;
        public DirectoryView(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
            MessageBox.Show(tableName);
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
