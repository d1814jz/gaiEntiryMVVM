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
    /// Interaction logic for EditAccountingView.xaml
    /// </summary>
    public partial class EditAccountingView : Window
    {
        public EditAccountingView(Accounting accountingToEdit)
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            RepositoriesVM.SelectedAccounting = accountingToEdit;
            RepositoriesVM.AccountingNumber = accountingToEdit.Number;
            RepositoriesVM.AccountingColor = accountingToEdit.Color;
            RepositoriesVM.AccountingidAuto = accountingToEdit.idAuto;
            RepositoriesVM.AccountingidDriver = accountingToEdit.idDriver;
            RepositoriesVM.AccountingidWorker = accountingToEdit.idWorker;
        }
    }
}
