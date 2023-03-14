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
    /// Interaction logic for EditIllegalTypeView.xaml
    /// </summary>
    public partial class EditIllegalTypeView : Window
    {
        public EditIllegalTypeView(IllegalType illegalTypeToEdit)
        {
            InitializeComponent();
            DataContext = new IllegalTypeViewModel();
            IllegalTypeViewModel.SelectedIllegalType = illegalTypeToEdit;
            IllegalTypeViewModel.IllegalTypeIllegalType1 = illegalTypeToEdit.IllegalType1;
            IllegalTypeViewModel.IllegalTypeFine = illegalTypeToEdit.Fine;
            IllegalTypeViewModel.IllegalTypeNotice = illegalTypeToEdit.Notice;
            IllegalTypeViewModel.IllegalTypeTod = illegalTypeToEdit.Tod;
        }
    }
}
