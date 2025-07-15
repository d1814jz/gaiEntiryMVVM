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
    class DistrictBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<District> _DistrictsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<District> _Districts;


        public ObservableCollection<District> Districts
        {
            get => _Districts;
            set
            {
                if (Set(ref _Districts, value))
                {
                    _Districts = value;
                    _DistrictsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DistrictsViewSource.View.Refresh();
                    //_Districts = value;

                    OnPropertyChanged(nameof(DistrictsView));
                }
            }
        }

        private CollectionViewSource _DistrictsViewSource;

        public ICollectionView DistrictsView => _DistrictsViewSource?.View;

        #region SelectedDistrict : District - Выбранный водитель

        /// <summary>Выбранный водитель</summary>
        private District _SelectedDistrict;

        /// <summary>Выбранный водитель</summary>
        public District SelectedDistrict { get => _SelectedDistrict; set => Set(ref _SelectedDistrict, value); }

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
            //_Districts = _DistrictsRepository.Items.ToObservableCollection(); 
            //Districts = (await _DistrictsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Districts = _DistrictsRepository.Items.ToObservableCollection();
            Districts = _DistrictsRepository.Items.ToObservableCollection();
            //_Districts = (await _DistrictsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDistrictCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewDistrictCommand;
        private ICommand _OnAddEditDistrictCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand AddNewDistrictCommand => _AddNewDistrictCommand
            ?? new LambdaCommand(OnAddNewDistrictCommandExecuted, CanAddNewDistrictCommandExecute);

        public ICommand OnAddEditDistrictCommand => _OnAddEditDistrictCommand
            ?? new LambdaCommand(OnAddEditDistrictCommandExecuted, CanAddNewDistrictCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewDistrictCommandExecute() => true;
        private bool CanAddEditDistrictCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        private void OnAddEditDistrictCommandExecuted()
        {
            var edit_District = SelectedDistrict;
            if (!_UserDialog.Edit(edit_District))
                return;
            _DistrictsRepository.Update(edit_District);
            DistrictsView.Refresh();
        }

        private void OnAddNewDistrictCommandExecuted()
        {
            var new_District = new District();

            if (!_UserDialog.Edit(new_District))
                return;
            //_DistrictsRepository.Add(new_District);
            Districts.Add(_DistrictsRepository.Add(new_District));

            SelectedDistrict = new_District;
        }

        #endregion

        #region Command RemoveDistrictCommand : District - Удаление водителя

        /// <summary>Удаление указанной водителя</summary>
        private ICommand _RemoveDistrictCommand;

        /// <summary>Удаление водителя</summary>
        public ICommand RemoveDistrictCommand => _RemoveDistrictCommand
            ?? new LambdaCommand<District>(OnRemoveDistrictCommandExecuted, CanRemoveDistrictCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление водителя</summary>
        private bool CanRemoveDistrictCommandExecute(District p) => p != null || SelectedDistrict != null;

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
        private void OnRemoveDistrictCommandExecuted(District p)
        {
            var District_to_remove = p ?? SelectedDistrict;

            if (!_UserDialog.ConfirmWarning($"Вы убрать район с территории обслуживания?", "Удление района"))
                return;

            _DistrictsRepository.Remove(District_to_remove.id);

            Districts.Remove(District_to_remove);
            if (ReferenceEquals(SelectedDistrict, District_to_remove))
                SelectedDistrict = null;
        }

        #endregion

        public DistrictBaseViewModel(IRepository<District> DistrictsRepository, IUserDialog UserDialog)
        {
            _DistrictsRepository = DistrictsRepository;
            _UserDialog = UserDialog;
        }
    }
}
