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
    
    public partial class AutoView : Window
    {
        gaiEngEntities db = new gaiEngEntities();


        private string tableName { get; set; }
        public AutoView()
        {
            InitializeComponent();
            AutoView_Load();

        }

        public void AutoView_Load()
        {

            dataGridView1.ItemsSource = db.Auto.ToList();
        }

        public void getDate(string tableName)
        {
            List<string> directoryTablesList = new List<string>() { "Auto", "Driver", "IllegalType", "Rank" };


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
