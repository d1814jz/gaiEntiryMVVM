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
    class WorkerBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Worker> _WorkerRepository;
        //public IRepository<Rank> _RankRepository;

        public IUserDialog _UserDialog;

        private ObservableCollection<Worker> _Worker;


        public ObservableCollection<Worker> Worker
        {
            get => _Worker;
            set
            {
                if (Set(ref _Worker, value))
                {
                    _Worker = value;
                    _WorkerViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _WorkerViewSource.View.Refresh();
                    //_Worker = value;

                    OnPropertyChanged(nameof(WorkerView));
                }
            }
        }

        private CollectionViewSource _WorkerViewSource;

        public ICollectionView WorkerView => _WorkerViewSource?.View;

        #region SelectedWorker : Worker - Выбранный звание

        /// <summary>Выбранный звание</summary>
        private Worker _SelectedWorker;

        /// <summary>Выбранный звание</summary>
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

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
            //_Worker = _WorkerRepository.Items.ToObservableCollection(); 
            //Worker = (await _WorkerRepository.Items.ToArrayAsync()).ToObservableCollection();
            //_Worker = _WorkerRepository.Items.ToObservableCollection();
            Worker = _WorkerRepository.Items.ToObservableCollection();
            //_Worker = (await _WorkerRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewWorkerCommand - Добавление нового сотрудника

        /// <summary>Добавление сотрудника</summary>
        private ICommand _AddNewWorkerCommand;
        private ICommand _OnAddEditWorkerCommand;

        /// <summary>Добавление сотрудника</summary>
        public ICommand AddNewWorkerCommand => _AddNewWorkerCommand
            ?? new LambdaCommand(OnAddNewWorkerCommandExecuted, CanAddNewWorkerCommandExecute);

        public ICommand OnAddEditWorkerCommand => _OnAddEditWorkerCommand
            ?? new LambdaCommand(OnAddEditWorkerCommandExecuted, CanAddNewWorkerCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление сотрудника</summary>
        private bool CanAddNewWorkerCommandExecute() => true;
        private bool CanAddEditWorkerCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление сотрудника</summary>

        private void OnAddEditWorkerCommandExecuted()
        {
            var edit_Worker = SelectedWorker;
            if (!_UserDialog.Edit(edit_Worker))
                return;
            _WorkerRepository.Update(edit_Worker);
            WorkerView.Refresh();
        }

        private void OnAddNewWorkerCommandExecuted()
        {
            var new_Worker = new Worker();

            if (!_UserDialog.Edit(new_Worker))
                return;
            //_WorkerRepository.Add(new_Worker);
            Worker.Add(_WorkerRepository.Add(new_Worker));

            SelectedWorker = new_Worker;
        }

        #endregion

        #region Command RemoveWorkerCommand : Worker - Удаление сотрудника

        /// <summary>Удаление указанной сотрудника</summary>
        private ICommand _RemoveWorkerCommand;

        /// <summary>Удаление сотрудника</summary>
        public ICommand RemoveWorkerCommand => _RemoveWorkerCommand
            ?? new LambdaCommand<Worker>(OnRemoveWorkerCommandExecuted, CanRemoveWorkerCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление сотрудника</summary>
        private bool CanRemoveWorkerCommandExecute(Worker p) => p != null || SelectedWorker != null;

        /// <summary>Проверка возможности выполнения - Удалениесотрудника</summary>
        private void OnRemoveWorkerCommandExecuted(Worker p)
        {
            var Worker_to_remove = p ?? SelectedWorker;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить сотрудника: {Worker_to_remove.FirsName} {Worker_to_remove.LastName} {Worker_to_remove.Surname}?", "Удаление сотрудника"))
                return;

            _WorkerRepository.Remove(Worker_to_remove.id);

            Worker.Remove(Worker_to_remove);
            if (ReferenceEquals(SelectedWorker, Worker_to_remove))
                SelectedWorker = null;
        }

        #endregion

        public WorkerBaseViewModel(IRepository<Worker> WorkerRepository, IUserDialog UserDialog)
        {
            _WorkerRepository = WorkerRepository;
            //_RankRepository = RankRepository;
            _UserDialog = UserDialog;
        }
    }
}
