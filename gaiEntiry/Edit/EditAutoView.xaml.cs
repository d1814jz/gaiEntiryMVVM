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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gaiEntiry.Edit
{
    /// <summary>
    /// Interaction logic for EditAutoView.xaml
    /// </summary>
    public partial class EditAutoView : Window
    {
        public EditAutoView(Auto autoToEdit)
        {
            InitializeComponent();
            DataContext = new AutoViewModel();
            AutoViewModel.SelectedAuto = autoToEdit;
            AutoViewModel.AutoModel = autoToEdit.Model;
            AutoViewModel.AutoBrand = autoToEdit.Brand;
            AutoViewModel.AutoYear = autoToEdit.Year;
            AutoViewModel.AutoVinNumber = autoToEdit.VinNumber;

            /*DataManageVM.SelectedDepartment = departmentToEdit;
            DataManageVM.DepartmentName = departmentToEdit.Name;*/

        }
    }
}
