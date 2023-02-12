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
            using (db)
            {
                var driver = db.Driver.Where(u => u.id == _id);
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

        private void btnInser_Click(object sender, RoutedEventArgs e)
        {
            using (db)
            {
                var result = db.Driver.Where(u => u.id == _id).FirstOrDefault(u => u.FirstName == FirstNameTextBox.Text & u.LastName == LastNameTextBox.Text & u.Surname == SurnameTextBox.Text & u.Address == AddressTextBox.Text & u.NumberDL == NumberDLTextBox.Text);
                if(result != null)
                {
                    MessageBox.Show(Convert.ToString(result));
                    db.SaveChanges();
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
