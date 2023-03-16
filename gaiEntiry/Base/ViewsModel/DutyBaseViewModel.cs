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
    class DutyBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Duty> _DutyRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Duty> _Duty;


        public ObservableCollection<Duty> Duty
        {
            get => _Duty;
            set
            {
                if (Set(ref _Duty, value))
                {
                    _Duty = value;
                    _DutyViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DutyViewSource.View.Refresh();
                    //_Duty = value;

                    OnPropertyChanged(nameof(DutyView));
                }
            }
        }

        private CollectionViewSource _DutyViewSource;

        public ICollectionView DutyView => _DutyViewSource?.View;

        #region SelectedDuty : Duty - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private Duty _SelectedDuty;

        /// <summary>Выбранный нарушение</summary>
        public Duty SelectedDuty { get => _SelectedDuty; set => Set(ref _SelectedDuty, value); }

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
            //_Duty = _DutyRepository.Items.ToObservableCollection(); 
            //Duty = (await _DutyRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Duty = _DutyRepository.Items.ToObservableCollection();
            Duty = _DutyRepository.Items.ToObservableCollection();
            //_Duty = (await _DutyRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDutyCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewDutyCommand;
        private ICommand _OnAddEditDutyCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewDutyCommand => _AddNewDutyCommand
            ?? new LambdaCommand(OnAddNewDutyCommandExecuted, CanAddNewDutyCommandExecute);

        public ICommand OnAddEditDutyCommand => _OnAddEditDutyCommand
            ?? new LambdaCommand(OnAddEditDutyCommandExecuted, CanAddNewDutyCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewDutyCommandExecute() => true;
        private bool CanAddEditDutyCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditDutyCommandExecuted()
        {
            var edit_Duty = SelectedDuty;
            if (!_UserDialog.Edit(edit_Duty))
                return;
            _DutyRepository.Update(edit_Duty);
            DutyView.Refresh();
        }

        private void OnAddNewDutyCommandExecuted()
        {
            var new_Duty = new Duty();

            if (!_UserDialog.Edit(new_Duty))
                return;
            //_DutyRepository.Add(new_Duty);
            Duty.Add(_DutyRepository.Add(new_Duty));

            SelectedDuty = new_Duty;
        }

        #endregion

        #region Command RemoveDutyCommand : Duty - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveDutyCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveDutyCommand => _RemoveDutyCommand
            ?? new LambdaCommand<Duty>(OnRemoveDutyCommandExecuted, CanRemoveDutyCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveDutyCommandExecute(Duty p) => p != null || SelectedDuty != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveDutyCommandExecuted(Duty p)
        {
            var Duty_to_remove = p ?? SelectedDuty;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить дежурство?", "Удаление дежурства"))
                return;

            _DutyRepository.Remove(Duty_to_remove.id);

            Duty.Remove(Duty_to_remove);
            if (ReferenceEquals(SelectedDuty, Duty_to_remove))
                SelectedDuty = null;
        }

        #endregion

        public DutyBaseViewModel(IRepository<Duty> DutyRepository, IUserDialog UserDialog)
        {
            _DutyRepository = DutyRepository;
            _UserDialog = UserDialog;
        }
    }
}
