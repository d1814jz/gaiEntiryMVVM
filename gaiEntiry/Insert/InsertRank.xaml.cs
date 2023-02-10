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
    /// Interaction logic for InsertRank.xaml
    /// </summary>
    public partial class InsertRank : Window
    {
        gaiEngEntities db = new gaiEngEntities();
        public InsertRank()
        {
            InitializeComponent();
        }

        private void btnInser_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new gaiEngEntities())
            {
                var newRank = new Rank(){
                    Rank1 = RankTextBox.Text
                };
                db.Rank.Add(newRank);
                db.SaveChanges();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
