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
    class RankBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Rank> _RankRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Rank> _Rank;


        public ObservableCollection<Rank> Rank
        {
            get => _Rank;
            set
            {
                if (Set(ref _Rank, value))
                {
                    _Rank = value;
                    _RankViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _RankViewSource.View.Refresh();
                    //_Rank = value;

                    OnPropertyChanged(nameof(RankView));
                }
            }
        }

        private CollectionViewSource _RankViewSource;

        public ICollectionView RankView => _RankViewSource?.View;

        #region SelectedRank : Rank - Выбранный звание

        /// <summary>Выбранный звание</summary>
        private Rank _SelectedRank;

        /// <summary>Выбранный звание</summary>
        public Rank SelectedRank { get => _SelectedRank; set => Set(ref _SelectedRank, value); }

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
            //_Rank = _RankRepository.Items.ToObservableCollection(); 
            //Rank = (await _RankRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Rank = _RankRepository.Items.ToObservableCollection();
            Rank = _RankRepository.Items.ToObservableCollection();
            //_Rank = (await _RankRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewRankCommand - Добавление нового звания

        /// <summary>Добавление звания</summary>
        private ICommand _AddNewRankCommand;
        private ICommand _OnAddEditRankCommand;

        /// <summary>Добавление звания</summary>
        public ICommand AddNewRankCommand => _AddNewRankCommand
            ?? new LambdaCommand(OnAddNewRankCommandExecuted, CanAddNewRankCommandExecute);

        public ICommand OnAddEditRankCommand => _OnAddEditRankCommand
            ?? new LambdaCommand(OnAddEditRankCommandExecuted, CanAddNewRankCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление звания</summary>
        private bool CanAddNewRankCommandExecute() => true;
        private bool CanAddEditRankCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление звания</summary>

        private void OnAddEditRankCommandExecuted()
        {
            var edit_Rank = SelectedRank;
            if (!_UserDialog.Edit(edit_Rank))
                return;
            _RankRepository.Update(edit_Rank);
            RankView.Refresh();
        }

        private void OnAddNewRankCommandExecuted()
        {
            var new_Rank = new Rank();

            if (!_UserDialog.Edit(new_Rank))
                return;
            //_RankRepository.Add(new_Rank);
            Rank.Add(_RankRepository.Add(new_Rank));

            SelectedRank = new_Rank;
        }

        #endregion

        #region Command RemoveRankCommand : Rank - Удаление звания

        /// <summary>Удаление указанной звания</summary>
        private ICommand _RemoveRankCommand;

        /// <summary>Удаление звания</summary>
        public ICommand RemoveRankCommand => _RemoveRankCommand
            ?? new LambdaCommand<Rank>(OnRemoveRankCommandExecuted, CanRemoveRankCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление звания</summary>
        private bool CanRemoveRankCommandExecute(Rank p) => p != null || SelectedRank != null;

        /// <summary>Проверка возможности выполнения - Удалениезвания</summary>
        private void OnRemoveRankCommandExecuted(Rank p)
        {
            var Rank_to_remove = p ?? SelectedRank;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить звание: {Rank_to_remove.Rank1}?", "Удаление звание"))
                return;

            _RankRepository.Remove(Rank_to_remove.id);

            Rank.Remove(Rank_to_remove);
            if (ReferenceEquals(SelectedRank, Rank_to_remove))
                SelectedRank = null;
        }

        #endregion

        public RankBaseViewModel(IRepository<Rank> RankRepository, IUserDialog UserDialog)
        {
            _RankRepository = RankRepository;
            _UserDialog = UserDialog;
        }
    }
}
