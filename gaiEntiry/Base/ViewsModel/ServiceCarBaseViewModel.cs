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
    class ServiceCarBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<ServiceCar> _ServiceCarsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<ServiceCar> _ServiceCars;


        public ObservableCollection<ServiceCar> ServiceCars
        {
            get => _ServiceCars;
            set
            {
                if (Set(ref _ServiceCars, value))
                {
                    _ServiceCars = value;
                    _ServiceCarsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _ServiceCarsViewSource.View.Refresh();
                    //_ServiceCars = value;

                    OnPropertyChanged(nameof(ServiceCarsView));
                }
            }
        }

        private CollectionViewSource _ServiceCarsViewSource;

        public ICollectionView ServiceCarsView => _ServiceCarsViewSource?.View;

        #region SelectedServiceCar : ServiceCar - Выбранный водитель

        /// <summary>Выбранный водитель</summary>
        private ServiceCar _SelectedServiceCar;

        /// <summary>Выбранный водитель</summary>
        public ServiceCar SelectedServiceCar { get => _SelectedServiceCar; set => Set(ref _SelectedServiceCar, value); }

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
            //_ServiceCars = _ServiceCarsRepository.Items.ToObservableCollection(); 
            //ServiceCars = (await _ServiceCarsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _ServiceCars = _ServiceCarsRepository.Items.ToObservableCollection();
            ServiceCars = _ServiceCarsRepository.Items.ToObservableCollection();
            //_ServiceCars = (await _ServiceCarsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewServiceCarCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewServiceCarCommand;
        private ICommand _OnAddEditServiceCarCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand AddNewServiceCarCommand => _AddNewServiceCarCommand
            ?? new LambdaCommand(OnAddNewServiceCarCommandExecuted, CanAddNewServiceCarCommandExecute);

        public ICommand OnAddEditServiceCarCommand => _OnAddEditServiceCarCommand
            ?? new LambdaCommand(OnAddEditServiceCarCommandExecuted, CanAddNewServiceCarCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewServiceCarCommandExecute() => true;
        private bool CanAddEditServiceCarCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        private void OnAddEditServiceCarCommandExecuted()
        {
            var edit_ServiceCar = SelectedServiceCar;
            if (!_UserDialog.Edit(edit_ServiceCar))
                return;
            _ServiceCarsRepository.Update(edit_ServiceCar);
            ServiceCarsView.Refresh();
        }

        private void OnAddNewServiceCarCommandExecuted()
        {
            var new_ServiceCar = new ServiceCar();

            if (!_UserDialog.Edit(new_ServiceCar))
                return;
            //_ServiceCarsRepository.Add(new_ServiceCar);
            ServiceCars.Add(_ServiceCarsRepository.Add(new_ServiceCar));

            SelectedServiceCar = new_ServiceCar;
        }

        #endregion

        #region Command RemoveServiceCarCommand : ServiceCar - Удаление водителя

        /// <summary>Удаление указанной водителя</summary>
        private ICommand _RemoveServiceCarCommand;

        /// <summary>Удаление водителя</summary>
        public ICommand RemoveServiceCarCommand => _RemoveServiceCarCommand
            ?? new LambdaCommand<ServiceCar>(OnRemoveServiceCarCommandExecuted, CanRemoveServiceCarCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление водителя</summary>
        private bool CanRemoveServiceCarCommandExecute(ServiceCar p) => p != null || SelectedServiceCar != null;

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
        private void OnRemoveServiceCarCommandExecuted(ServiceCar p)
        {
            var ServiceCar_to_remove = p ?? SelectedServiceCar;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить служебный автомобиль {SelectedServiceCar.Model} {SelectedServiceCar.Brand} {SelectedServiceCar.Number}?", "Удаление автомобиля"))
                return;

            _ServiceCarsRepository.Remove(ServiceCar_to_remove.id);

            ServiceCars.Remove(ServiceCar_to_remove);
            if (ReferenceEquals(SelectedServiceCar, ServiceCar_to_remove))
                SelectedServiceCar = null;
        }

        #endregion

        public ServiceCarBaseViewModel(IRepository<ServiceCar> ServiceCarsRepository, IUserDialog UserDialog)
        {
            _ServiceCarsRepository = ServiceCarsRepository;
            _UserDialog = UserDialog;
        }
    }
}
