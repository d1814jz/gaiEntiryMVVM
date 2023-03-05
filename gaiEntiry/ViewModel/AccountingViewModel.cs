using gaiEntiry.Add;
using gaiEntiry.Edit;
using gaiEntiry.Repositories;
using gaiEntiry.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry.ViewModel
{
    class AccountingViewModel
    {

        public static int Accountingid { get; set; }
        public static int AccountingidWorker { get; set; }
        public static int AccountingidDriver { get; set; }
        public static int AccountingidAuto { get; set; }
        public static string AccountingNumber { get; set; }
        public static string AccountingColor { get; set; }
        public static System.DateTime AccountingFirstDate { get; set; }
        public static System.DateTime AccountingLastDate { get; set; }
        public static Accounting SelectedAccounting { get; set; }
        public static Auto AccountingAuto { get; set; }
        public static Driver AccountingDriver { get; set; }
        public static Worker AccountingWorker { get; set; }

        private List<Accounting> allAccountings = AccountingRepositories.GetAllAccountings();
        public List<Accounting> AllAccountings
        {
            get { return allAccountings; }
            set
            {
                allAccountings = value;
                NotifyPropertyChanged("AllAccountings");
            }
        }

        private List<Driver> allDrivers = DriverRepositories.GetAllDrivers();
        public List<Driver> AllDrivers
        {
            get { return allDrivers; }
            set
            {
                allDrivers = value;
                NotifyPropertyChanged("AllDrivers");
            }
        }

        private static List<Auto> allAutos = AutoRepositories.GetAllAutos();
        public List<Auto> AllAutos
        {
            get { return allAutos; }
            set
            {
                allAutos = value;
                NoticePropertyChanged(nameof(AllAutos));
                //NotifyPropertyChanged("AllAutos");
            }
        }

        private List<Worker> allWorkers = WorkerRepositories.GetAllWorkers();
        public List<Worker> AllWorkers
        {
            get { return allWorkers; }
            set
            {
                allWorkers = value;
                NotifyPropertyChanged("AllWorkers");
            }
        }


        private RelayCommand addNewAccounting;
        public RelayCommand AddNewAccounting
        {
            get
            {
                return addNewAccounting ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (AccountingColor != null && AccountingNumber != null)
                    {
                        resultStr = AccountingRepositories.CreateAccounting(AccountingNumber, AccountingColor, AccountingFirstDate, AccountingLastDate,
                            AccountingWorker, AccountingDriver, AccountingAuto);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllAccountingsView();
                    }
                });
            }
        }

        private RelayCommand editAccounting;
        public RelayCommand EditAccounting
        {
            get
            {
                return editAccounting ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (AccountingColor != null && AccountingNumber != null && AccountingAuto != null && AccountingidDriver != null
                        && AccountingidWorker != null)
                    {
                        resultStr = AccountingRepositories.EditAccounting(SelectedAccounting, AccountingNumber, AccountingColor, AccountingFirstDate, AccountingLastDate, AccountingWorker, AccountingDriver, AccountingAuto);
                        ShowMessageToUser(resultStr);
                       // SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllAccountingsView();
                    }
                });
            }
        }

        private RelayCommand deleteAccounting;
        public RelayCommand DeleteAccounting
        {
            get
            {
                return deleteAccounting ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedAccounting != null)
                    {
                        resultStr = AccountingRepositories.DeleteAccounting(SelectedAccounting);
                        //SetNullValuesToProperties();
                        UpdateAllAccountingsView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        public void UpdateAllAccountingsView()
        {
            AllAccountings = AccountingRepositories.GetAllAccountings();
            AccountingView.AllAccountingsView.ItemsSource = null;
            AccountingView.AllAccountingsView.Items.Clear();
            AccountingView.AllAccountingsView.ItemsSource = allAccountings;
            AccountingView.AllAccountingsView.Items.Refresh();
        }

        private void OpenAddNewAccountingViewMethod()
        {
            AddNewAccountingView obj = new AddNewAccountingView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditAccountingViewMethod(Accounting Accounting)
        {
            EditAccountingView obj = new EditAccountingView(Accounting);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editAccountingView;
        public RelayCommand EditAccountingView
        {
            get
            {
                return editAccountingView ?? new RelayCommand(obj =>
                {
                    OpenEditAccountingViewMethod(SelectedAccounting);
                });
            }
        }

        private RelayCommand openAddNewAccountingView;
        public RelayCommand OpenAddNewAccountingView
        {
            get
            {
                return openAddNewAccountingView ?? new RelayCommand(obj =>
                {
                    OpenAddNewAccountingViewMethod();
                });
            }
        }

        #region Inotify


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void NoticePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion
    }
}
