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

namespace gaiEntiry.Update
{
    /// <summary>
    /// Interaction logic for UpdateDriver.xaml
    /// </summary>
    public partial class UpdateDriver : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        private int _id { get; set; }
        public void setValues()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var driver = db.Driver.Where(u => u.id == _id).FirstOrDefault();
                if(driver != null)
                {
                    FirstNameTextBox.Text = driver.FirstName;
                    LastNameTextBox.Text = driver.LastName;
                    SurnameTextBox.Text = driver.Surname;
                    AddressTextBox.Text = driver.Address;
                    NumberDLTextBox.Text = driver.NumberDL;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                
                //извлечь данные !?
            }
        }
        public UpdateDriver(int id)
        {
            InitializeComponent();
            this._id = id;
            MessageBox.Show(Convert.ToString(id));
            setValues();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                //var result = db.Driver.Where(u => u.id == _id).FirstOrDefault(u => u.FirstName == FirstNameTextBox.Text & u.LastName == LastNameTextBox.Text & u.Surname == SurnameTextBox.Text & u.Address == AddressTextBox.Text & u.NumberDL == NumberDLTextBox.Text);
                var result = db.Driver.Where(u => u.id == _id).FirstOrDefault();
                if (result != null)
                {
                    result.FirstName = FirstNameTextBox.Text;
                    result.LastName = LastNameTextBox.Text;
                    result.Surname = SurnameTextBox.Text;
                    result.Address = AddressTextBox.Text;
                    result.NumberDL = NumberDLTextBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные изменены");
                    setValues();
                }

            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
