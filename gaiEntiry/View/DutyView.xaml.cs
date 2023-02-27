using gaiEntiry.ViewModel;
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

namespace gaiEntiry.View
{
    /// <summary>
    /// Interaction logic for DutyView.xaml
    /// </summary>
    public partial class DutyView : Window
    {
        public static ListView AllDutiesView;
        public DutyView()
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            AllDutiesView = ViewAllDuties;

        }
    }
}
