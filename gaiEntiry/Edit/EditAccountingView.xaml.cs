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
            DataContext = new AccountingViewModel();
            AccountingViewModel.SelectedAccounting = accountingToEdit;
            AccountingViewModel.AccountingNumber = accountingToEdit.Number;
            AccountingViewModel.AccountingColor = accountingToEdit.Color;
            AccountingViewModel.AccountingidAuto = accountingToEdit.idAuto;
            AccountingViewModel.AccountingidDriver = accountingToEdit.idDriver;
            AccountingViewModel.AccountingidWorker = accountingToEdit.idWorker;
        }
    }
}
