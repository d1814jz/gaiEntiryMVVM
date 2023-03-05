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
    class WorkerViewModel
    {
        public static int Workerid { get; set; }
        public static int WorkeridRank { get; set; }
        public static string WorkerLastName { get; set; }
        public static string WorkerFirstName { get; set; }
        public static string WorkerSurname { get; set; }
        public static Worker SelectedWorker { get; set; }
        public static Rank WorkerRank { get; set; }
        public static Accounting WorkerAccounting { get; set; }

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

        private List<Rank> allRanks = RankRepositories.GetAllRanks();
        public List<Rank> AllRanks
        {
            get { return allRanks; }
            set
            {
                allRanks = value;
                NotifyPropertyChanged("AllRanks");
            }
        }


        private RelayCommand addNewWorker;
        public RelayCommand AddNewWorker
        {
            get
            {
                return addNewWorker ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (WorkerFirstName != null && WorkerLastName != null && WorkerSurname != null)
                    {
                        resultStr = WorkerRepositories.CreateWorker(WorkerLastName, WorkerFirstName, WorkerSurname, WorkerRank);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllWorkersView();
                    }
                });
            }
        }

        private RelayCommand editWorker;
        public RelayCommand EditWorker
        {
            get
            {
                return editWorker ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedWorker != null)
                    {
                        resultStr = WorkerRepositories.EditWorker(SelectedWorker, WorkerLastName, WorkerFirstName, WorkerSurname, WorkerRank);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();

                        wnd.Close();
                        UpdateAllWorkersView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteWorker;
        public RelayCommand DeleteWorker
        {
            get
            {
                return deleteWorker ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedWorker != null)
                    {
                        resultStr = WorkerRepositories.DeleteWorker(SelectedWorker);
                        //SetNullValuesToProperties();
                        UpdateAllWorkersView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private void UpdateAllWorkersView()
        {
            AllWorkers = WorkerRepositories.GetAllWorkers();
            WorkerView.AllWorkersView.ItemsSource = null;
            WorkerView.AllWorkersView.Items.Clear();
            WorkerView.AllWorkersView.ItemsSource = allWorkers;
            WorkerView.AllWorkersView.Items.Refresh();
        }

        private void OpenAddNewWorkerViewMethod()
        {
            AddNewWorkerView obj = new AddNewWorkerView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewWorkerView;
        public RelayCommand OpenAddNewWorkerView
        {
            get
            {
                return openAddNewWorkerView ?? new RelayCommand(obj =>
                {
                    OpenAddNewWorkerViewMethod();
                });
            }
        }


        private void EditWorkerViewMethod(Worker Worker)
        {
            EditWorkerView obj = new EditWorkerView(Worker);
            SetCenterPositionAndOpen(obj);
        }
        private RelayCommand editWorkerView;
        public RelayCommand EditWorkerView
        {
            get
            {
                return editWorkerView ?? new RelayCommand(obj =>
                {
                    EditWorkerViewMethod(SelectedWorker);
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
