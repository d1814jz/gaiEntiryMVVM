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
    class AccountingBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Accounting> _AccountingsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Accounting> _Accountings;


        public ObservableCollection<Accounting> Accountings
        {
            get => _Accountings;
            set
            {
                if (Set(ref _Accountings, value))
                {
                    _Accountings = value;
                    _AccountingsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AccountingsViewSource.View.Refresh();
                    //_Accountings = value;

                    OnPropertyChanged(nameof(AccountingsView));
                }
            }
        }

        private CollectionViewSource _AccountingsViewSource;

        public ICollectionView AccountingsView => _AccountingsViewSource?.View;

        #region SelectedAccounting : Accounting - Выбранный водитель

        /// <summary>Выбранный водитель</summary>
        private Accounting _SelectedAccounting;

        /// <summary>Выбранный водитель</summary>
        public Accounting SelectedAccounting { get => _SelectedAccounting; set => Set(ref _SelectedAccounting, value); }

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
            //_Accountings = _AccountingsRepository.Items.ToObservableCollection(); 
            //Accountings = (await _AccountingsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Accountings = _AccountingsRepository.Items.ToObservableCollection();
            Accountings = _AccountingsRepository.Items.ToObservableCollection();
            //_Accountings = (await _AccountingsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAccountingCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewAccountingCommand;
        private ICommand _OnAddEditAccountingCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand AddNewAccountingCommand => _AddNewAccountingCommand
            ?? new LambdaCommand(OnAddNewAccountingCommandExecuted, CanAddNewAccountingCommandExecute);

        public ICommand OnAddEditAccountingCommand => _OnAddEditAccountingCommand
            ?? new LambdaCommand(OnAddEditAccountingCommandExecuted, CanAddNewAccountingCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewAccountingCommandExecute() => true;
        private bool CanAddEditAccountingCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        private void OnAddEditAccountingCommandExecuted()
        {
            var edit_Accounting = SelectedAccounting;
            if (!_UserDialog.Edit(edit_Accounting))
                return;
            _AccountingsRepository.Update(edit_Accounting);
            AccountingsView.Refresh();
        }

        private void OnAddNewAccountingCommandExecuted()
        {
            var new_Accounting = new Accounting();

            if (!_UserDialog.Edit(new_Accounting))
                return;
            //_AccountingsRepository.Add(new_Accounting);
            Accountings.Add(_AccountingsRepository.Add(new_Accounting));

            SelectedAccounting = new_Accounting;
        }

        #endregion

        #region Command RemoveAccountingCommand : Accounting - Удаление водителя

        /// <summary>Удаление указанной водителя</summary>
        private ICommand _RemoveAccountingCommand;

        /// <summary>Удаление водителя</summary>
        public ICommand RemoveAccountingCommand => _RemoveAccountingCommand
            ?? new LambdaCommand<Accounting>(OnRemoveAccountingCommandExecuted, CanRemoveAccountingCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление водителя</summary>
        private bool CanRemoveAccountingCommandExecute(Accounting p) => p != null || SelectedAccounting != null;

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
        private void OnRemoveAccountingCommandExecuted(Accounting p)
        {
            var Accounting_to_remove = p ?? SelectedAccounting;

            if (!_UserDialog.ConfirmWarning($"Вы хотите снять автомобиль с учета?", "Снятие с учета"))
                return;

            _AccountingsRepository.Remove(Accounting_to_remove.id);

            Accountings.Remove(Accounting_to_remove);
            if (ReferenceEquals(SelectedAccounting, Accounting_to_remove))
                SelectedAccounting = null;
        }

        #endregion

        public AccountingBaseViewModel(IRepository<Accounting> AccountingsRepository, IUserDialog UserDialog)
        {
            _AccountingsRepository = AccountingsRepository;
            _UserDialog = UserDialog;
        }
    }
}
