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

namespace gaiEntiry.Insert
{
    /// <summary>
    /// Interaction logic for InserDriver.xaml
    /// </summary>
    public partial class InsertDriver : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        public InsertDriver()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new gaiEngEntities())
            {
                var newDriver = new Driver()
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Address = AddressTextBox.Text,
                    NumberDL = NumberDLTextBox.Text
                };
                db.Driver.Add(newDriver);
                db.SaveChanges();
            }



        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

    }
}
