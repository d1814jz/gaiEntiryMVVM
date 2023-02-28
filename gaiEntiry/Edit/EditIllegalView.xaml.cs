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
    /// Interaction logic for EditIllegalView.xaml
    /// </summary>
    public partial class EditIllegalView : Window
    {
        public EditIllegalView(Illegal illegalToEdit)
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            RepositoriesVM.SelectedIllegal = illegalToEdit;
            RepositoriesVM.IllegalDescription = illegalToEdit.Description;
            RepositoriesVM.IllegalPlace = illegalToEdit.Place;
            /*RepositoriesVM.IllegalidAuto = illegalToEdit.idAuto;
            RepositoriesVM.IllegalidDriver = illegalToEdit.idDriver;
            RepositoriesVM.IllegalidDuty = illegalToEdit.idDuty;
            RepositoriesVM.IllegalidIllegalType = illegalToEdit.idIllegalType;*/

        }
    }
}
