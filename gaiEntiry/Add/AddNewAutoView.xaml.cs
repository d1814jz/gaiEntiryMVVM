using gaiEntiry.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace gaiEntiry.Add
{
    /// <summary>
    /// Interaction logic for AddNewAutoWindow.xaml
    /// </summary>
    public partial class AddNewAutoView : Window
    {
        public AddNewAutoView()
        {
            InitializeComponent();
            DataContext = new AutoViewModel();
        }
    }
}
