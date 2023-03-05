using gaiEntiry.Add;
using gaiEntiry.Edit;
using gaiEntiry.Repositories;
using gaiEntiry.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry.ViewModel
{
    class AutoViewModel
    {
        public static int Autoid { get; set; }
        public static string AutoBrand { get; set; }
        public static string AutoModel { get; set; }
        public static int AutoYear { get; set; }
        public static string AutoVinNumber { get; set; }
        public static Auto SelectedAuto { get; set; }
        public static Illegal AutoIllegal { get; set; }
        //все автомобили
        private static List<Auto> allAutos = AutoRepositories.GetAllAutos();
        //public static List<Auto> list = Repositories.GetAllAutos();
        private ObservableCollection<Auto> allAutosOc = AutoRepositories.GetAllAutosOc();
        public ObservableCollection<Auto> AllAutosOc
        {
            get { return allAutosOc; }
            set
            {
                allAutosOc = value;
                NoticePropertyChanged(nameof(AllAutosOc));
            }
        }
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

        private RelayCommand addNewAuto;
        public RelayCommand AddNewAuto
        {

            get
            {
                return addNewAuto ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (AutoBrand != null && AutoModel != null & AutoYear != 0 && AutoVinNumber != null)
                    {
                        resultStr = AutoRepositories.CreateAuto(AutoBrand, AutoModel, AutoYear, AutoVinNumber);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllAutoView();
                    }
                });
            }

        }

        private RelayCommand editAuto;
        public RelayCommand EditAuto
        {
            get
            {
                return editAuto ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Автомобиль не выбран";
                    if (SelectedAuto != null)
                    {
                        resultStr = AutoRepositories.EditAuto(SelectedAuto, AutoBrand, AutoModel, AutoYear, AutoVinNumber);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();

                        wnd.Close();
                        UpdateAllAutoView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteAuto;
        public RelayCommand DeleteAuto
        {
            get
            {
                return deleteAuto ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedAuto != null)
                    {
                        resultStr = AutoRepositories.DeleteAuto(SelectedAuto);
                        UpdateAllAutoView();
                        //SetNullValuesToProperties();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }
        private void UpdateAllAutoView()
        {
            AllAutos = AutoRepositories.GetAllAutos();
            AutoView.AllAutosView.ItemsSource = null;
            AutoView.AllAutosView.Items.Clear();
            AutoView.AllAutosView.ItemsSource = allAutos;
            AutoView.AllAutosView.Items.Refresh();
        }

        private void OpenAddNewAutoViewMethod()
        {
            AddNewAutoView obj = new AddNewAutoView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewAutoView;
        public RelayCommand OpenAddNewAutoView
        {
            get
            {
                return openAddNewAutoView ?? new RelayCommand(obj =>
                {
                    OpenAddNewAutoViewMethod();
                });
            }
        }

        private void EditAutoViewMethod(Auto auto)
        {
            EditAutoView obj = new EditAutoView(auto);
            SetCenterPositionAndOpen(obj);
        }
        private RelayCommand editAutoView;
        public RelayCommand EditAutoView
        {
            get
            {
                return editAutoView ?? new RelayCommand(obj =>
                {
                    EditAutoViewMethod(SelectedAuto);
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
