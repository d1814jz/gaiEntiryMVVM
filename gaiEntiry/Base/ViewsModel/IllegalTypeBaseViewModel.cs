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
    class IllegalTypeBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<IllegalType> _IllegalTypeRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<IllegalType> _IllegalType;


        public ObservableCollection<IllegalType> IllegalType
        {
            get => _IllegalType;
            set
            {
                if (Set(ref _IllegalType, value))
                {
                    _IllegalType = value;
                    _IllegalTypeViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _IllegalTypeViewSource.View.Refresh();
                    //_IllegalType = value;

                    OnPropertyChanged(nameof(IllegalTypeView));
                }
            }
        }

        private CollectionViewSource _IllegalTypeViewSource;

        public ICollectionView IllegalTypeView => _IllegalTypeViewSource?.View;

        #region SelectedIllegalType : IllegalType - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private IllegalType _SelectedIllegalType;

        /// <summary>Выбранный нарушение</summary>
        public IllegalType SelectedIllegalType { get => _SelectedIllegalType; set => Set(ref _SelectedIllegalType, value); }

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
            //_IllegalType = _IllegalTypeRepository.Items.ToObservableCollection(); 
            //IllegalType = (await _IllegalTypeRepository.Items.ToArrayAsync()).ToObservableCollection();
            _IllegalType = _IllegalTypeRepository.Items.ToObservableCollection();
            IllegalType = _IllegalTypeRepository.Items.ToObservableCollection();
            //_IllegalType = (await _IllegalTypeRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewIllegalTypeCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewIllegalTypeCommand;
        private ICommand _OnAddEditIllegalTypeCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewIllegalTypeCommand => _AddNewIllegalTypeCommand
            ?? new LambdaCommand(OnAddNewIllegalTypeCommandExecuted, CanAddNewIllegalTypeCommandExecute);

        public ICommand OnAddEditIllegalTypeCommand => _OnAddEditIllegalTypeCommand
            ?? new LambdaCommand(OnAddEditIllegalTypeCommandExecuted, CanAddNewIllegalTypeCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewIllegalTypeCommandExecute() => true;
        private bool CanAddEditIllegalTypeCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditIllegalTypeCommandExecuted()
        {
            var edit_IllegalType = SelectedIllegalType;
            if (!_UserDialog.Edit(edit_IllegalType))
                return;
            _IllegalTypeRepository.Update(edit_IllegalType);
            IllegalTypeView.Refresh();
        }

        private void OnAddNewIllegalTypeCommandExecuted()
        {
            var new_IllegalType = new IllegalType();

            if (!_UserDialog.Edit(new_IllegalType))
                return;
            //_IllegalTypeRepository.Add(new_IllegalType);
            IllegalType.Add(_IllegalTypeRepository.Add(new_IllegalType));

            SelectedIllegalType = new_IllegalType;
        }

        #endregion

        #region Command RemoveIllegalTypeCommand : IllegalType - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveIllegalTypeCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveIllegalTypeCommand => _RemoveIllegalTypeCommand
            ?? new LambdaCommand<IllegalType>(OnRemoveIllegalTypeCommandExecuted, CanRemoveIllegalTypeCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveIllegalTypeCommandExecute(IllegalType p) => p != null || SelectedIllegalType != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveIllegalTypeCommandExecuted(IllegalType p)
        {
            var IllegalType_to_remove = p ?? SelectedIllegalType;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить вид нарушения: {IllegalType_to_remove.IllegalType1}?", "Удаление вида нарушения"))
                return;

            _IllegalTypeRepository.Remove(IllegalType_to_remove.id);

            IllegalType.Remove(IllegalType_to_remove);
            if (ReferenceEquals(SelectedIllegalType, IllegalType_to_remove))
                SelectedIllegalType = null;
        }

        #endregion

        public IllegalTypeBaseViewModel(IRepository<IllegalType> IllegalTypeRepository, IUserDialog UserDialog)
        {
            _IllegalTypeRepository = IllegalTypeRepository;
            _UserDialog = UserDialog;
        }
    }
}
