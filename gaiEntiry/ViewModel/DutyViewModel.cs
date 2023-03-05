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
    class DutyViewModel
    {
        public static int Dutyid { get; set; }
        public static int DutyidWorker { get; set; }
        public static System.DateTime DutyDate { get; set; }
        public static string DutyPlace { get; set; }
        public static Duty SelectedDuty { get; set; }
        public static Worker DutyWorker { get; set; }
        public static Illegal DutyIllegal { get; set; }
        private List<Duty> allDuties = DutyRepositories.GetAllDuties();
        public List<Duty> AllDuties
        {
            get { return allDuties; }
            set
            {
                allDuties = value;
                NotifyPropertyChanged("AllDutys");
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

        private RelayCommand addNewDuty;
        public RelayCommand AddNewDuty
        {
            get
            {
                return addNewDuty ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (DutyDate != null && DutyPlace != null)
                    {
                        resultStr = DutyRepositories.CreateDuty(DutyDate, DutyPlace, DutyWorker);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllDutiesView();
                    }
                });
            }
        }

        private RelayCommand editDuty;
        public RelayCommand EditDuty
        {
            get
            {
                return editDuty ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedDuty != null)
                    {
                        resultStr = DutyRepositories.EditDuty(SelectedDuty, DutyDate, DutyPlace, DutyWorker);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllDutiesView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteDuty;
        public RelayCommand DeleteDuty
        {
            get
            {
                return deleteDuty ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedDuty != null)
                    {
                        resultStr = DutyRepositories.DeleteDuty(SelectedDuty);
                        //SetNullValuesToProperties();
                        UpdateAllDutiesView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        public void UpdateAllDutiesView()
        {
            AllDuties = DutyRepositories.GetAllDuties();
            DutyView.AllDutiesView.ItemsSource = null;
            DutyView.AllDutiesView.Items.Clear();
            DutyView.AllDutiesView.ItemsSource = allDuties;
            DutyView.AllDutiesView.Items.Refresh();
        }

        private void OpenAddNewDutyViewMethod()
        {
            AddNewDutyView obj = new AddNewDutyView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditDutyViewMethod(Duty Duty)
        {
            EditDutyView obj = new EditDutyView(Duty);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editDutyView;
        public RelayCommand EditDutyView
        {
            get
            {
                return editDutyView ?? new RelayCommand(obj =>
                {
                    OpenEditDutyViewMethod(SelectedDuty);
                });
            }
        }

        private RelayCommand openAddNewDutyView;
        public RelayCommand OpenAddNewDutyView
        {
            get
            {
                return openAddNewDutyView ?? new RelayCommand(obj =>
                {
                    OpenAddNewDutyViewMethod();
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
