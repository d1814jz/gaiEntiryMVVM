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
    class DutyDotsTypeBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<DutyDotsType> _DutyDotsTypeRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<DutyDotsType> _DutyDotsType;


        public ObservableCollection<DutyDotsType> DutyDotsType
        {
            get => _DutyDotsType;
            set
            {
                if (Set(ref _DutyDotsType, value))
                {
                    _DutyDotsType = value;
                    _DutyDotsTypeViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DutyDotsTypeViewSource.View.Refresh();
                    //_DutyDotsType = value;

                    OnPropertyChanged(nameof(DutyDotsTypeView));
                }
            }
        }

        private CollectionViewSource _DutyDotsTypeViewSource;

        public ICollectionView DutyDotsTypeView => _DutyDotsTypeViewSource?.View;

        #region SelectedDutyDotsType : DutyDotsType - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private DutyDotsType _SelectedDutyDotsType;

        /// <summary>Выбранный нарушение</summary>
        public DutyDotsType SelectedDutyDotsType { get => _SelectedDutyDotsType; set => Set(ref _SelectedDutyDotsType, value); }

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
            //_DutyDotsType = _DutyDotsTypeRepository.Items.ToObservableCollection(); 
            //DutyDotsType = (await _DutyDotsTypeRepository.Items.ToArrayAsync()).ToObservableCollection();
            _DutyDotsType = _DutyDotsTypeRepository.Items.ToObservableCollection();
            DutyDotsType = _DutyDotsTypeRepository.Items.ToObservableCollection();
            //_DutyDotsType = (await _DutyDotsTypeRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDutyDotsTypeCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewDutyDotsTypeCommand;
        private ICommand _OnAddEditDutyDotsTypeCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewDutyDotsTypeCommand => _AddNewDutyDotsTypeCommand
            ?? new LambdaCommand(OnAddNewDutyDotsTypeCommandExecuted, CanAddNewDutyDotsTypeCommandExecute);

        public ICommand OnAddEditDutyDotsTypeCommand => _OnAddEditDutyDotsTypeCommand
            ?? new LambdaCommand(OnAddEditDutyDotsTypeCommandExecuted, CanAddNewDutyDotsTypeCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewDutyDotsTypeCommandExecute() => true;
        private bool CanAddEditDutyDotsTypeCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditDutyDotsTypeCommandExecuted()
        {
            var edit_DutyDotsType = SelectedDutyDotsType;
            if (!_UserDialog.Edit(edit_DutyDotsType))
                return;
            _DutyDotsTypeRepository.Update(edit_DutyDotsType);
            DutyDotsTypeView.Refresh();
        }

        private void OnAddNewDutyDotsTypeCommandExecuted()
        {
            var new_DutyDotsType = new DutyDotsType();

            if (!_UserDialog.Edit(new_DutyDotsType))
                return;
            //_DutyDotsTypeRepository.Add(new_DutyDotsType);
            DutyDotsType.Add(_DutyDotsTypeRepository.Add(new_DutyDotsType));

            SelectedDutyDotsType = new_DutyDotsType;
        }

        #endregion

        #region Command RemoveDutyDotsTypeCommand : DutyDotsType - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveDutyDotsTypeCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveDutyDotsTypeCommand => _RemoveDutyDotsTypeCommand
            ?? new LambdaCommand<DutyDotsType>(OnRemoveDutyDotsTypeCommandExecuted, CanRemoveDutyDotsTypeCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveDutyDotsTypeCommandExecute(DutyDotsType p) => p != null || SelectedDutyDotsType != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveDutyDotsTypeCommandExecuted(DutyDotsType p)
        {
            var DutyDotsType_to_remove = p ?? SelectedDutyDotsType;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить тип точки дежурства?", "Удаление точки дежурства"))
                return;

            _DutyDotsTypeRepository.Remove(DutyDotsType_to_remove.id);

            DutyDotsType.Remove(DutyDotsType_to_remove);
            if (ReferenceEquals(SelectedDutyDotsType, DutyDotsType_to_remove))
                SelectedDutyDotsType = null;
        }

        #endregion

        public DutyDotsTypeBaseViewModel(IRepository<DutyDotsType> DutyDotsTypeRepository, IUserDialog UserDialog)
        {
            _DutyDotsTypeRepository = DutyDotsTypeRepository;
            _UserDialog = UserDialog;
        }
    }
}
