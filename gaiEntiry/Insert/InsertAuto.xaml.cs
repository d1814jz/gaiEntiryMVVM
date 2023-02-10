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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace gaiEntiry.Insert
{
    /// <summary>
    /// Interaction logic for InsertAuto.xaml
    /// </summary>
    public partial class InsertAuto : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        public InsertAuto()
        {
            InitializeComponent();
        }

        private void btnInser_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new gaiEngEntities())
            {
                var newAuto = new Auto()
                {
                    Brand = BrandTextBox.Text,
                    Model = ModelTextBox.Text,
                    Year = Convert.ToInt32(YearTextBox.Text),
                    VinNumber = VinNumberTextBox.Text
                };
                db.Auto.Add(newAuto);
                db.SaveChanges();
            }
            


        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
        
}
