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
    /// Interaction logic for EditIllegalTypeView.xaml
    /// </summary>
    public partial class EditIllegalTypeView : Window
    {
        public EditIllegalTypeView(IllegalType illegalTypeToEdit)
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            RepositoriesVM.SelectedIllegalType = illegalTypeToEdit;
            RepositoriesVM.IllegalTypeIllegalType1 = illegalTypeToEdit.IllegalType1;
            RepositoriesVM.IllegalTypeFine = illegalTypeToEdit.Fine;
            RepositoriesVM.IllegalTypeNotice = illegalTypeToEdit.Notice;
            RepositoriesVM.IllegalTypeTod = illegalTypeToEdit.Tod;
        }
    }
}
