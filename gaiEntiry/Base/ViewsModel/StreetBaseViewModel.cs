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
    class StreetBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Street> _StreetRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Street> _Street;


        public ObservableCollection<Street> Street
        {
            get => _Street;
            set
            {
                if (Set(ref _Street, value))
                {
                    _Street = value;
                    _StreetViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _StreetViewSource.View.Refresh();
                    //_Street = value;

                    OnPropertyChanged(nameof(StreetView));
                }
            }
        }

        private CollectionViewSource _StreetViewSource;

        public ICollectionView StreetView => _StreetViewSource?.View;

        #region SelectedStreet : Street - Выбранный звание

        /// <summary>Выбранный звание</summary>
        private Street _SelectedStreet;

        /// <summary>Выбранный звание</summary>
        public Street SelectedStreet { get => _SelectedStreet; set => Set(ref _SelectedStreet, value); }

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
            //_Street = _StreetRepository.Items.ToObservableCollection(); 
            //Street = (await _StreetRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Street = _StreetRepository.Items.ToObservableCollection();
            Street = _StreetRepository.Items.ToObservableCollection();
            //_Street = (await _StreetRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewStreetCommand - Добавление нового звания

        /// <summary>Добавление звания</summary>
        private ICommand _AddNewStreetCommand;
        private ICommand _OnAddEditStreetCommand;

        /// <summary>Добавление звания</summary>
        public ICommand AddNewStreetCommand => _AddNewStreetCommand
            ?? new LambdaCommand(OnAddNewStreetCommandExecuted, CanAddNewStreetCommandExecute);

        public ICommand OnAddEditStreetCommand => _OnAddEditStreetCommand
            ?? new LambdaCommand(OnAddEditStreetCommandExecuted, CanAddNewStreetCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление звания</summary>
        private bool CanAddNewStreetCommandExecute() => true;
        private bool CanAddEditStreetCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление звания</summary>

        private void OnAddEditStreetCommandExecuted()
        {
            var edit_Street = SelectedStreet;
            if (!_UserDialog.Edit(edit_Street))
                return;
            _StreetRepository.Update(edit_Street);
            StreetView.Refresh();
        }

        private void OnAddNewStreetCommandExecuted()
        {
            var new_Street = new Street();

            if (!_UserDialog.Edit(new_Street))
                return;
            //_StreetRepository.Add(new_Street);
            Street.Add(_StreetRepository.Add(new_Street));

            SelectedStreet = new_Street;
        }

        #endregion

        #region Command RemoveStreetCommand : Street - Удаление звания

        /// <summary>Удаление указанной звания</summary>
        private ICommand _RemoveStreetCommand;

        /// <summary>Удаление звания</summary>
        public ICommand RemoveStreetCommand => _RemoveStreetCommand
            ?? new LambdaCommand<Street>(OnRemoveStreetCommandExecuted, CanRemoveStreetCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление звания</summary>
        private bool CanRemoveStreetCommandExecute(Street p) => p != null || SelectedStreet != null;

        /// <summary>Проверка возможности выполнения - Удалениезвания</summary>
        private void OnRemoveStreetCommandExecuted(Street p)
        {
            var Street_to_remove = p ?? SelectedStreet;

            if (!_UserDialog.ConfirmWarning($"Вы хотите снять улицу {SelectedStreet.Street1} с территории обслуживания?", "Удаление улицы"))
                return;

            _StreetRepository.Remove(Street_to_remove.id);

            Street.Remove(Street_to_remove);
            if (ReferenceEquals(SelectedStreet, Street_to_remove))
                SelectedStreet = null;
        }

        #endregion

        public StreetBaseViewModel(IRepository<Street> StreetRepository, IUserDialog UserDialog)
        {
            _StreetRepository = StreetRepository;
            _UserDialog = UserDialog;
        }
    }
}
