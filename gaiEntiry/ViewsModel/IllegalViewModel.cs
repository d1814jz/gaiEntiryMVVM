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

namespace gaiEntiry.ViewsModel
{
    class IllegalViewModel
    {
        

        public static int Illegalid { get; set; }
        public static int IllegalidIllegalType { get; set; }
        public static int IllegalidDuty { get; set; }
        public static int IllegalidAuto { get; set; }
        public static int IllegalidDriver { get; set; }
        public static string IllegalPlace { get; set; }
        public static string IllegalDescription { get; set; }
        public static Illegal SelectedIllegal { get; set; }
        public static Auto IllegalAuto { get; set; }
        public static Driver IllegalDriver { get; set; }
        public static Duty IllegalDuty { get; set; }
        public static IllegalType IllegalIllegalType { get; set; }

        private List<Illegal> allIllegals = IllegalRepositories.GetAllIllegals();
        public List<Illegal> AllIllegals
        {
            get { return allIllegals; }
            set
            {
                allIllegals = value;
                NotifyPropertyChanged("AllIllegals");
            }
        }

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

        private List<IllegalType> allIllegalTypes = IllegalTypeRepositories.GetAllIllegalTypes();
        public List<IllegalType> AllIllegalTypes
        {
            get { return allIllegalTypes; }
            set
            {
                allIllegalTypes = value;
                NotifyPropertyChanged("AllIllegalTypes");
            }
        }

        private RelayCommand addNewIllegal;
        public RelayCommand AddNewIllegal
        {
            get
            {
                return addNewIllegal ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (IllegalPlace != null && IllegalDescription != null)
                    {
                        resultStr = IllegalRepositories.CreateIllegal(IllegalPlace, IllegalDescription, IllegalIllegalType, IllegalDuty, IllegalAuto, IllegalDriver);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllIllegalsView();
                    }
                });
            }
        }

        private RelayCommand editIllegal;
        public RelayCommand EditIllegal
        {
            get
            {
                return editIllegal ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedIllegal != null)
                    {
                        resultStr = IllegalRepositories.EditIllegal(SelectedIllegal, IllegalPlace, IllegalDescription, IllegalIllegalType,
                            IllegalDuty, IllegalAuto, IllegalDriver);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllIllegalsView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteIllegal;
        public RelayCommand DeleteIllegal
        {
            get
            {
                return deleteIllegal ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedIllegal != null)
                    {
                        resultStr = IllegalRepositories.DeleteIllegal(SelectedIllegal);
                        //SetNullValuesToProperties();
                        UpdateAllIllegalsView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        public void UpdateAllIllegalsView()
        {
            AllIllegals = IllegalRepositories.GetAllIllegals();
            IllegalView.AllIllegalsView.ItemsSource = null;
            IllegalView.AllIllegalsView.Items.Clear();
            IllegalView.AllIllegalsView.ItemsSource = allIllegals;
            IllegalView.AllIllegalsView.Items.Refresh();
        }

        private void OpenAddNewIllegalViewMethod()
        {
            AddNewIllegalView obj = new AddNewIllegalView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditIllegalViewMethod(Illegal Illegal)
        {
            EditIllegalView obj = new EditIllegalView(Illegal);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editIllegalView;
        public RelayCommand EditIllegalView
        {
            get
            {
                return editIllegalView ?? new RelayCommand(obj =>
                {
                    OpenEditIllegalViewMethod(SelectedIllegal);
                });
            }
        }

        private RelayCommand openAddNewIllegalView;
        public RelayCommand OpenAddNewIllegalView
        {
            get
            {
                return openAddNewIllegalView ?? new RelayCommand(obj =>
                {
                    OpenAddNewIllegalViewMethod();
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
