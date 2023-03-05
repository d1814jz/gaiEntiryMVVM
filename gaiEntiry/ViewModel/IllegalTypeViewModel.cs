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
    class IllegalTypeViewModel
    {
        public static int IllegalTypeid { get; set; }
        public static string IllegalTypeIllegalType1 { get; set; }
        public static int IllegalTypeFine { get; set; }
        public static bool IllegalTypeNotice { get; set; }
        public static int IllegalTypeTod { get; set; }
        public static IllegalType SelectedIllegalType { get; set; }
        public static Illegal IllegalTypeIllegal { get; set; }
        //все виды нарущение

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

        private RelayCommand addNewIllegalType;
        public RelayCommand AddNewIllegalType
        {

            get
            {
                return addNewIllegalType ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (IllegalTypeIllegalType1 != null)
                    {
                        resultStr = IllegalTypeRepositories.CreateIllegalType(IllegalTypeIllegalType1, IllegalTypeFine, IllegalTypeNotice, IllegalTypeTod);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllIllegalTypesView();
                    }
                });
            }
        }

        private RelayCommand deleteIllegalType;
        public RelayCommand DeleteIllegalType
        {
            get
            {
                return deleteIllegalType ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedIllegalType != null)
                    {
                        resultStr = IllegalTypeRepositories.DeleteIllegalType(SelectedIllegalType);
                        //SetNullValuesToProperties();
                        UpdateAllIllegalTypesView();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editIllegalType;
        public RelayCommand EditIllegalType
        {
            get
            {
                return editIllegalType ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Вид нарушения не выбран";
                    if (SelectedIllegalType != null)
                    {
                        resultStr = IllegalTypeRepositories.EditIllegalType(SelectedIllegalType, IllegalTypeIllegalType1, IllegalTypeFine, IllegalTypeNotice, IllegalTypeTod);
                        ShowMessageToUser(resultStr);
                        //SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }



        private void UpdateAllIllegalTypesView()
        {
            AllIllegalTypes = IllegalTypeRepositories.GetAllIllegalTypes();
            IllegalTypeView.AllIllegalTypesView.ItemsSource = null;
            IllegalTypeView.AllIllegalTypesView.Items.Clear();
            IllegalTypeView.AllIllegalTypesView.ItemsSource = AllIllegalTypes;
            IllegalTypeView.AllIllegalTypesView.Items.Refresh();
        }

        private void OpenAddNewIllegalTypeViewMethod()
        {
            AddNewIllegalTypeView obj = new AddNewIllegalTypeView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewIllegalTypeView;
        public RelayCommand OpenAddNewIllegalTypeView
        {
            get
            {
                return openAddNewIllegalTypeView ?? new RelayCommand(obj =>
                {
                    OpenAddNewIllegalTypeViewMethod();
                });
            }
        }
        private RelayCommand editIllegalTypeView;
        public RelayCommand EditIllegalTypeView
        {
            get
            {
                return editIllegalTypeView ?? new RelayCommand(obj =>
                {
                    OpenEditIllegalTypeViewMethod(SelectedIllegalType);
                });
            }
        }


        private void OpenEditIllegalTypeViewMethod(IllegalType illegalType)
        {
            EditIllegalTypeView obj = new EditIllegalTypeView(illegalType);
            SetCenterPositionAndOpen(obj);
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
