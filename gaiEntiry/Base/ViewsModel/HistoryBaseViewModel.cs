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
    class HistoryBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<History> _HistoryRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<History> _History;


        public ObservableCollection<History> History
        {
            get => _History;
            set
            {
                if (Set(ref _History, value))
                {
                    _History = value;
                    _HistoryViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _HistoryViewSource.View.Refresh();
                    //_History = value;

                    OnPropertyChanged(nameof(HistoryView));
                }
            }
        }

        private CollectionViewSource _HistoryViewSource;

        public ICollectionView HistoryView => _HistoryViewSource?.View;

        #region SelectedHistory : History - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private History _SelectedHistory;

        /// <summary>Выбранный нарушение</summary>
        public History SelectedHistory { get => _SelectedHistory; set => Set(ref _SelectedHistory, value); }

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
            //_History = _HistoryRepository.Items.ToObservableCollection(); 
            //History = (await _HistoryRepository.Items.ToArrayAsync()).ToObservableCollection();
            _History = _HistoryRepository.Items.ToObservableCollection();
            History = _HistoryRepository.Items.ToObservableCollection();
            //_History = (await _HistoryRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewHistoryCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewHistoryCommand;
        private ICommand _OnAddEditHistoryCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewHistoryCommand => _AddNewHistoryCommand
            ?? new LambdaCommand(OnAddNewHistoryCommandExecuted, CanAddNewHistoryCommandExecute);

        public ICommand OnAddEditHistoryCommand => _OnAddEditHistoryCommand
            ?? new LambdaCommand(OnAddEditHistoryCommandExecuted, CanAddNewHistoryCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewHistoryCommandExecute() => true;
        private bool CanAddEditHistoryCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditHistoryCommandExecuted()
        {
            var edit_History = SelectedHistory;
            if (!_UserDialog.Edit(edit_History))
                return;
            _HistoryRepository.Update(edit_History);
            HistoryView.Refresh();
        }

        private void OnAddNewHistoryCommandExecuted()
        {
            var new_History = new History();

            if (!_UserDialog.Edit(new_History))
                return;
            //_HistoryRepository.Add(new_History);
            History.Add(_HistoryRepository.Add(new_History));

            SelectedHistory = new_History;
        }

        #endregion

        #region Command RemoveHistoryCommand : History - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveHistoryCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveHistoryCommand => _RemoveHistoryCommand
            ?? new LambdaCommand<History>(OnRemoveHistoryCommandExecuted, CanRemoveHistoryCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveHistoryCommandExecute(History p) => p != null || SelectedHistory != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveHistoryCommandExecuted(History p)
        {
            var History_to_remove = p ?? SelectedHistory;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить запись в истории?", "Удаление записи"))
                return;

            _HistoryRepository.Remove(History_to_remove.id);

            History.Remove(History_to_remove);
            if (ReferenceEquals(SelectedHistory, History_to_remove))
                SelectedHistory = null;
        }

        #endregion

        public HistoryBaseViewModel(IRepository<History> HistoryRepository, IUserDialog UserDialog)
        {
            _HistoryRepository = HistoryRepository;
            _UserDialog = UserDialog;
        }
    }
}
