using gaiEntiry.ViewsModel;
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

namespace gaiEntiry.Edit
{
    /// <summary>
    /// Interaction logic for EditWorker.xaml
    /// </summary>
    public partial class EditWorkerView : Window
    {
        public EditWorkerView(Worker workerToEdit)
        {
            InitializeComponent();
            DataContext = new WorkerViewModel();
            WorkerViewModel.SelectedWorker = workerToEdit;
            WorkerViewModel.WorkerLastName = workerToEdit.LastName;
            WorkerViewModel.WorkerFirstName = workerToEdit.FirsName;
            WorkerViewModel.WorkerSurname = workerToEdit.Surname;
            WorkerViewModel.WorkeridRank = workerToEdit.idRank;
        }
    }
}
