using gaiEntiry.Base.View;
using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace gaiEntiry.Base.ViewsModel
{
    class AuthorizationBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Log> LogRepository = App.Services.GetService(typeof(IRepository<Log>)) as IRepository<Log>;
        public ObservableCollection<Log> LogsView
        {
            get => LogRepository.Items.ToObservableCollection();
        }

        private string _UserLogin;
        public string UserLogin { get => _UserLogin; set => Set(ref _UserLogin, value); }

        private string _UserPassword;
        public string UserPassword { get => _UserPassword; set => Set(ref _UserPassword, value); }

        public IRepository<User> _AuthorizationsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<User> _Authorizations;


        public ObservableCollection<User> Authorizations
        {
            get => _Authorizations;
            set
            {
                if (Set(ref _Authorizations, value))
                {
                    _Authorizations = value;
                    _AuthorizationsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AuthorizationsViewSource.View.Refresh();
                    //_Authorizations = value;

                    OnPropertyChanged(nameof(AuthorizationsView));
                }
            }
        }

        private CollectionViewSource _AuthorizationsViewSource;

        public ICollectionView AuthorizationsView => _AuthorizationsViewSource?.View;

        #region SelectedAuthorization : Authorization - Выбранный водитель


        #endregion

        #region Command LoadDataCommand - Команда загрузки данных из репозитория

        /// <summary>Команда загрузки данных из репозитория</summary>
        private ICommand _LoadDataCommand;

        /// <summary>Команда загрузки данных из репозитория</summary>
        /// ??=
        public ICommand LoadDataCommand => _LoadDataCommand
            ?? new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда загрузки данных из репозитория</summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary>Логика выполнения - Команда загрузки данных из репозитория</summary>
        private async Task OnLoadDataCommandExecuted()
        {
            //_Authorizations = _AuthorizationsRepository.Items.ToObservableCollection(); 
            //Authorizations = (await _AuthorizationsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Authorizations = _AuthorizationsRepository.Items.ToObservableCollection();
            Authorizations = _AuthorizationsRepository.Items.ToObservableCollection();
            //_Authorizations = (await _AuthorizationsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAuthorizationCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewAuthorizationCommand;
        private ICommand _OnAddEditAuthorizationCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand OnLoginCommand => new LambdaCommand(OnMenuCommandExecuted);
        private void OnMenuCommandExecuted()
        {

            User user = Authorizations.Find(u => u.Login == UserLogin && u.Password == UserPassword);
            if (user is null)
            {
                if (!_UserDialog.ConfirmWarning($"Не правильный логин или пароль!", "Ошибка"))
                    return;
            }
            else
            {
                /*Customer customer = new Customer
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Age = 30
                };*/
                Log logToAdd = new Log
                {
                    Login = user.Login,
                    Date = DateTime.Now
                };
                LogRepository.Add(logToAdd);

                if (user.Type == 1)
                {
                    MenuBaseView obj = new MenuBaseView();
                    SetCenterPositionAndOpen(obj);

                }
                if(user.Type == 2)
                {
                    MenuNchBaseView obj = new MenuNchBaseView();
                    SetCenterPositionAndOpen(obj);
                }
                if(user.Type == 3) 
                {
                    MenuOperBaseView obj = new MenuOperBaseView();
                    SetCenterPositionAndOpen(obj);
                }
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            Window window1 = App.Current.MainWindow;
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window1.Visibility = Visibility.Hidden;
            window.ShowDialog();
            
            //window.ShowDialog();
            
        }
        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewAuthorizationCommandExecute() => true;
        private bool CanAddEditAuthorizationCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
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

        #endregion

        public AuthorizationBaseViewModel(IRepository<User> AuthorizationsRepository, IUserDialog UserDialog)
        {
            _AuthorizationsRepository = AuthorizationsRepository;
            _UserDialog = UserDialog;
        }
    }
}
