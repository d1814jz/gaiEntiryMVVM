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
    class LogBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Log> _LogsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Log> _Logs;


        public ObservableCollection<Log> Logs
        {
            get => _Logs;
            set
            {
                if (Set(ref _Logs, value))
                {
                    _Logs = value;
                    _LogsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _LogsViewSource.View.Refresh();
                    OnPropertyChanged(nameof(LogsView));
                }
            }
        }

        private CollectionViewSource _LogsViewSource;

        public ICollectionView LogsView => _LogsViewSource?.View;



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
            //_Logs = _LogsRepository.Items.ToObservableCollection(); 
            //Logs = (await _LogsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Logs = _LogsRepository.Items.ToObservableCollection();
            Logs = _LogsRepository.Items.ToObservableCollection();
            //_Logs = (await _LogsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        

        public LogBaseViewModel(IRepository<Log> LogsRepository, IUserDialog UserDialog)
        {
            _LogsRepository = LogsRepository;
            _UserDialog = UserDialog;
        }
    }
}
