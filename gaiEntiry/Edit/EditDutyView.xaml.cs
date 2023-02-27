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

namespace gaiEntiry.Edit
{
    /// <summary>
    /// Interaction logic for EditDutyView.xaml
    /// </summary>
    public partial class EditDutyView : Window
    {
        public EditDutyView(Duty dutyToEdit)
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            RepositoriesVM.SelectedDuty = dutyToEdit;
            RepositoriesVM.DutyDate = dutyToEdit.Date;
            RepositoriesVM.DutyPlace = dutyToEdit.Place;
            RepositoriesVM.DutyidWorker = dutyToEdit.idWorker;

        }
    }
}
