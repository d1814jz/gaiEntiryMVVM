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
using gaiEntiry;

namespace gaiEntiry.Views
{

    public partial class DictionaryView : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        

        private string tableName { get; set; }
        public DictionaryView(string tableName)
        {
            this.tableName = tableName;
            DictionaryView_Load();
        }
        public DictionaryView()
        {
            InitializeComponent();
            this.tableName = tableName;

        }

        public void DictionaryView_Load()
        {
            
            InitializeComponent();
            
            MessageBox.Show(tableName);
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
            OtherCommands.getInsertWindow(tableName);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TextBlock currentId = (TextBlock)dataGridView1.SelectedCells[0].Column.GetCellContent(dataGridView1.SelectedItem);
            OtherCommands.getUpdateWindow(tableName, Convert.ToInt32(currentId.Text));

            
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

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //получение оси абсцисс
            //int index = dataGridView1.CurrentCell.Column.DisplayIndex;
            //MessageBox.Show(dataGridView1.CurrentColumn.DisplayIndex.ToString());
            MessageBox.Show(dataGridView1.CurrentColumn.DisplayIndex.ToString());
            
        }
    }
}
