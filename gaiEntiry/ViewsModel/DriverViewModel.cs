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
    class DriverViewModel
    {
        public static int Driverid { get; set; }
        public static string DriverLastName { get; set; }
        public static string DriverFirstName { get; set; }
        public static string DriverSurname { get; set; }
        public static string DriverAddress { get; set; }
        public static string DriverNumberDL { get; set; }
        public static Driver SelectedDriver { get; set; }
        public static Illegal DriverIllegal { get; set; }
        public static Accounting DriverAccounting { get; set; }
        //все водители

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

        RelayCommand addNewDriver;
        public RelayCommand AddNewDriver
        {
            get
            {
                return addNewDriver ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (DriverFirstName != null && DriverLastName != null && DriverSurname != null &&
                        DriverAddress != null && DriverNumberDL != null)
                    {
                        resultStr = DriverRepositories.CreateDriver(DriverLastName, DriverFirstName, DriverSurname, DriverAddress, DriverNumberDL);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllDriversView();
                    }
                });

            }
        }

        private RelayCommand deleteDriver;
        public RelayCommand DeleteDriver
        {
            get
            {
                return deleteDriver ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedDriver != null)
                    {
                        resultStr = DriverRepositories.DeleteDriver(SelectedDriver);
                        //SetNullValuesToProperties();
                        UpdateAllDriversView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editDriver;
        public RelayCommand EditDriver
        {
            get
            {
                return editDriver ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Автомобиль не выбран";
                    if (SelectedDriver != null)
                    {
                        resultStr = DriverRepositories.EditDriver(SelectedDriver, DriverLastName, DriverFirstName, DriverSurname, DriverAddress, DriverNumberDL);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private void UpdateAllDriversView()
        {
            AllDrivers = DriverRepositories.GetAllDrivers();
            DriverView.AllDriversView.ItemsSource = null;
            DriverView.AllDriversView.Items.Clear();
            DriverView.AllDriversView.ItemsSource = allDrivers;
            DriverView.AllDriversView.Items.Refresh();
        }

        private void OpenAddNewDriverViewMethod()
        {
            AddNewDriverView obj = new AddNewDriverView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewDriverView;
        public RelayCommand OpenAddNewDriverView
        {
            get
            {
                return openAddNewDriverView ?? new RelayCommand(obj =>
                {
                    OpenAddNewDriverViewMethod();
                });
            }
        }
        private void OpenEditDriverViewMethod(Driver driver)
        {
            EditDriverView obj = new EditDriverView(driver);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editDriverView;
        public RelayCommand EditDriverView
        {
            get
            {
                return editDriverView ?? new RelayCommand(obj =>
                {
                    OpenEditDriverViewMethod(SelectedDriver);
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
