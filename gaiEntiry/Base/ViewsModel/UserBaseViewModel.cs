using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace gaiEntiry.Base.ViewsModel
{
    class UserBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<User> _UserRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<User> _User;


        public ObservableCollection<User> User
        {
            get => _User;
            set
            {
                if (Set(ref _User, value))
                {
                    _User = value;
                    _UserViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _UserViewSource.View.Refresh();
                    //_User = value;

                    OnPropertyChanged(nameof(UserView));
                }
            }
        }

        private CollectionViewSource _UserViewSource;

        public ICollectionView UserView => _UserViewSource?.View;

        #region SelectedUser : User - Выбранный звание

        /// <summary>Выбранный звание</summary>
        private User _SelectedUser;

        /// <summary>Выбранный звание</summary>
        public User SelectedUser { get => _SelectedUser; set => Set(ref _SelectedUser, value); }

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
            //_User = _UserRepository.Items.ToObservableCollection(); 
            //User = (await _UserRepository.Items.ToArrayAsync()).ToObservableCollection();
            _User = _UserRepository.Items.ToObservableCollection();
            User = _UserRepository.Items.ToObservableCollection();
            //_User = (await _UserRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewUserCommand - Добавление нового звания

        /// <summary>Добавление звания</summary>
        private ICommand _AddNewUserCommand;
        private ICommand _OnAddEditUserCommand;

        /// <summary>Добавление звания</summary>
        public ICommand AddNewUserCommand => _AddNewUserCommand
            ?? new LambdaCommand(OnAddNewUserCommandExecuted, CanAddNewUserCommandExecute);

        public ICommand OnAddEditUserCommand => _OnAddEditUserCommand
            ?? new LambdaCommand(OnAddEditUserCommandExecuted, CanAddNewUserCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление звания</summary>
        private bool CanAddNewUserCommandExecute() => true;
        private bool CanAddEditUserCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление звания</summary>

        private void OnAddEditUserCommandExecuted()
        {
            var edit_User = SelectedUser;
            if (!_UserDialog.Edit(edit_User))
                return;
            _UserRepository.Update(edit_User);
            UserView.Refresh();
        }

        private void OnAddNewUserCommandExecuted()
        {
            var new_User = new User();

            if (!_UserDialog.Edit(new_User))
                return;
            //_UserRepository.Add(new_User);
            User.Add(_UserRepository.Add(new_User));

            SelectedUser = new_User;
        }

        #endregion

        #region Command RemoveUserCommand : User - Удаление звания

        /// <summary>Удаление указанной звания</summary>
        private ICommand _RemoveUserCommand;

        /// <summary>Удаление звания</summary>
        public ICommand RemoveUserCommand => _RemoveUserCommand
            ?? new LambdaCommand<User>(OnRemoveUserCommandExecuted, CanRemoveUserCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление звания</summary>
        private bool CanRemoveUserCommandExecute(User p) => p != null || SelectedUser != null;

        /// <summary>Проверка возможности выполнения - Удалениезвания</summary>
        private void OnRemoveUserCommandExecuted(User p)
        {
            var User_to_remove = p ?? SelectedUser;

            if (!_UserDialog.ConfirmWarning($"Вы хотите пользовател: {User_to_remove.Login}?", "Удаление пользователя"))
                return;

            _UserRepository.Remove(User_to_remove.id);

            User.Remove(User_to_remove);
            if (ReferenceEquals(SelectedUser, User_to_remove))
                SelectedUser = null;
        }

        #endregion

        public UserBaseViewModel(IRepository<User> UserRepository, IUserDialog UserDialog)
        {
            _UserRepository = UserRepository;
            _UserDialog = UserDialog;
        }
    }
}
