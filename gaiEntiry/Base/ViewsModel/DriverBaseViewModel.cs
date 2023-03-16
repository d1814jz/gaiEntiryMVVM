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
    class DriverBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Driver> _DriversRepository;
        public IUserDialog _UserDialog;
        
        private ObservableCollection<Driver> _Drivers;


        public ObservableCollection<Driver> Drivers
        {
            get => _Drivers;
            set
            {
                if (Set(ref _Drivers, value))
                {
                    _Drivers = value;
                    _DriversViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DriversViewSource.View.Refresh();
                    //_Drivers = value;

                    OnPropertyChanged(nameof(DriversView));
                }
            }
        }

        private CollectionViewSource _DriversViewSource;

        public ICollectionView DriversView => _DriversViewSource?.View;

        #region SelectedDriver : Driver - Выбранный водитель

        /// <summary>Выбранный водитель</summary>
        private Driver _SelectedDriver;

        /// <summary>Выбранный водитель</summary>
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

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
            //_Drivers = _DriversRepository.Items.ToObservableCollection(); 
            //Drivers = (await _DriversRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Drivers = _DriversRepository.Items.ToObservableCollection();
            Drivers = _DriversRepository.Items.ToObservableCollection();
            //_Drivers = (await _DriversRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDriverCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewDriverCommand;
        private ICommand _OnAddEditDriverCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand AddNewDriverCommand => _AddNewDriverCommand
            ?? new LambdaCommand(OnAddNewDriverCommandExecuted, CanAddNewDriverCommandExecute);

        public ICommand OnAddEditDriverCommand => _OnAddEditDriverCommand
            ?? new LambdaCommand(OnAddEditDriverCommandExecuted, CanAddNewDriverCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewDriverCommandExecute() => true;
        private bool CanAddEditDriverCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        private void OnAddEditDriverCommandExecuted()
        {
            var edit_Driver = SelectedDriver;
            if (!_UserDialog.Edit(edit_Driver))
                return;
            _DriversRepository.Update(edit_Driver);
            DriversView.Refresh();
        }

        private void OnAddNewDriverCommandExecuted()
        {
            var new_Driver = new Driver();

            if (!_UserDialog.Edit(new_Driver))
                return;
            //_DriversRepository.Add(new_Driver);
            Drivers.Add(_DriversRepository.Add(new_Driver));

            SelectedDriver = new_Driver;
        }

        #endregion

        #region Command RemoveDriverCommand : Driver - Удаление водителя

        /// <summary>Удаление указанной водителя</summary>
        private ICommand _RemoveDriverCommand;

        /// <summary>Удаление водителя</summary>
        public ICommand RemoveDriverCommand => _RemoveDriverCommand
            ?? new LambdaCommand<Driver>(OnRemoveDriverCommandExecuted, CanRemoveDriverCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление водителя</summary>
        private bool CanRemoveDriverCommandExecute(Driver p) => p != null || SelectedDriver != null;

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
        private void OnRemoveDriverCommandExecuted(Driver p)
        {
            var Driver_to_remove = p ?? SelectedDriver;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить водителя {Driver_to_remove.LastName} {Driver_to_remove.FirstName} {Driver_to_remove.Surname}?", "Удаление водителя"))
                return;

            _DriversRepository.Remove(Driver_to_remove.id);

            Drivers.Remove(Driver_to_remove);
            if (ReferenceEquals(SelectedDriver, Driver_to_remove))
                SelectedDriver = null;
        }

        #endregion

        public DriverBaseViewModel(IRepository<Driver> DriversRepository, IUserDialog UserDialog)
        {
            _DriversRepository = DriversRepository;
            _UserDialog = UserDialog;
        }
    }
}
