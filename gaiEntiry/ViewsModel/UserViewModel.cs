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
    class UserViewModel
    {

        //+пользователь свойства
        int Userid { get; set; }
        public static User SelectedUser { get; set; }

        private string _userLogin;
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                NotifyPropertyChanged(nameof(UserLogin));
            }
        }
        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                NotifyPropertyChanged(nameof(UserPassword));
            }
        }
        string UserType { get; set; }

        private List<User> allUsers = UserRepositories.GetAllUsers();
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    User user = allUsers.Find(u => u.Login == UserLogin && u.Password == UserPassword);
                    if (user is null)
                    {
                        ShowMessageToUser("Ошибка");
                    }
                    else
                    {
                        MenuView menuView = new MenuView();
                        SetCenterPositionAndOpen(menuView);
                        //SetNullValuesToProperties();


                    }

                });
            }
        }

        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ?? new RelayCommand(obj =>
                {
                    Application.Current.Shutdown();



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
