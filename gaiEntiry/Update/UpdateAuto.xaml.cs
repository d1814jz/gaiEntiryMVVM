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
    /// Interaction logic for UpdateAuto.xaml
    /// </summary>
    public partial class UpdateAuto : Window
    {
        private int _id { get; set; }
        public void setValues()
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var auto = db.Auto.Where(u => u.id == _id).FirstOrDefault();
                if(auto != null)
                {
                    BrandTextBox.Text = auto.Brand;
                    ModelTextBox.Text = auto.Model;
                    YearTextBox.Text = Convert.ToString(auto.Year);
                    VinNumberTextBox.Text = auto.VinNumber;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }           
            }
        }
        public UpdateAuto(int id)
        {
            InitializeComponent();
            this._id = id;
            MessageBox.Show(Convert.ToString(id));
            setValues();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Auto.Where(u => u.id == _id).FirstOrDefault();
                if(result != null)
                {
                    result.Model = ModelTextBox.Text;
                    result.Brand = BrandTextBox.Text;
                    result.Year = Convert.ToInt32(YearTextBox.Text);
                    result.VinNumber = VinNumberTextBox.Text;
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
