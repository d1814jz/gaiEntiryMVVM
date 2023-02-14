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
    /// Interaction logic for IsnertIllegalType.xaml
    /// </summary>
    public partial class InsertIllegalType : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        public InsertIllegalType()
        {
            InitializeComponent();
        }

        private void btnInser_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new gaiEngEntities())
            {
                var newIllegalType = new IllegalType()
                {
                    IllegalType1 = IllegalTypeTextBox.Text,
                    Fine = Convert.ToInt32(FineTextBox.Text),
                    Notice = NoticeCheckBox.IsEnabled ? true : false,
                    Tod = Convert.ToInt32(TodTextBox.Text)


                };
                db.IllegalType.Add(newIllegalType);
                db.SaveChanges();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
