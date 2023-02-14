using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for UpdateIllegalType.xaml
    /// </summary>
    public partial class UpdateIllegalType : Window
    {
        private int _id { get; set; }

        public void setValues()
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var illegalType = db.IllegalType.Where(u => u.id == _id).FirstOrDefault();
                if(illegalType != null)
                {
                    IllegalTypeTextBox.Text = illegalType.IllegalType1;
                    FineTextBox.Text = Convert.ToString(illegalType.Fine);
                    MessageBox.Show(Convert.ToString( illegalType.Notice));
                    _ = illegalType.Notice == true ? NoticeCheckBox.IsChecked = true : NoticeCheckBox.IsChecked = false;
                    TodTextBox.Text = Convert.ToString(illegalType.Tod);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
            }

        }
        public UpdateIllegalType(int id)
        {
            InitializeComponent();
            this._id = id;
            MessageBox.Show(Convert.ToString(id));
            setValues();
        }

        private void btnInser_Click(object sender, RoutedEventArgs e)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var illegalType = db.IllegalType.Where(u => u.id == _id).FirstOrDefault();
                if(illegalType != null)
                {
                    //Ошибка!
                    illegalType.IllegalType1 = IllegalTypeTextBox.Text;
                    illegalType.Fine = Convert.ToInt32(FineTextBox.Text);
                    _ = NoticeCheckBox.IsChecked == true ? illegalType.Notice = true : illegalType.Notice = false;
                    illegalType.Tod = Convert.ToInt32(TodTextBox.Text);
                    try
                    {

                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            MessageBox.Show(" ");
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + " ");
                            }
                        }
                    }
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
