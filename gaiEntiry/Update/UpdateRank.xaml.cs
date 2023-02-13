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
    /// Interaction logic for UpdateRank.xaml
    /// </summary>
    public partial class UpdateRank : Window
    {
        private int _id { get; set; }
        public void setValues()
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var rank = db.Rank.Where(u => u.id == _id).FirstOrDefault();
                if(rank != null)
                {
                    RankTextBox.Text = rank.Rank1;
                    MessageBox.Show("Данные обновлены");
                    db.SaveChanges();
                }
            }
        }

       public UpdateRank(int id)
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
                var rank = db.Rank.Where(u => u.id == _id).FirstOrDefault(); 
                if(rank != null)
                {
                    rank.Rank1 = RankTextBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные изменены"); ;
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
