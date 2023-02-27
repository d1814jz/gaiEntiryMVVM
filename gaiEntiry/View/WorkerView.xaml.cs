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
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : Window
    {
        public static ListView AllWorkersView;
        public WorkerView()
        {
            InitializeComponent();
            AllWorkersView = ViewAllWorkers;
            DataContext = new RepositoriesVM();
        }
    }
}
