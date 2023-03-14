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
    /// Interaction logic for EditDutyView.xaml
    /// </summary>
    public partial class EditDutyView : Window
    {
        public EditDutyView(Duty dutyToEdit)
        {
            InitializeComponent();
            DataContext = new DutyViewModel();
            DutyViewModel.SelectedDuty = dutyToEdit;
            DutyViewModel.DutyDate = dutyToEdit.Date;
            DutyViewModel.DutyPlace = dutyToEdit.Place;
            DutyViewModel.DutyidWorker = dutyToEdit.idWorker;

        }
    }
}
