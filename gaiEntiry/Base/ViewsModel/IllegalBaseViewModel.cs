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
    class IllegalBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Illegal> _IllegalRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Illegal> _Illegal;


        public ObservableCollection<Illegal> Illegal
        {
            get => _Illegal;
            set
            {
                if (Set(ref _Illegal, value))
                {
                    _Illegal = value;
                    _IllegalViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _IllegalViewSource.View.Refresh();
                    //_Illegal = value;

                    OnPropertyChanged(nameof(IllegalView));
                }
            }
        }

        private CollectionViewSource _IllegalViewSource;

        public ICollectionView IllegalView => _IllegalViewSource?.View;

        #region SelectedIllegal : Illegal - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private Illegal _SelectedIllegal;

        /// <summary>Выбранный нарушение</summary>
        public Illegal SelectedIllegal { get => _SelectedIllegal; set => Set(ref _SelectedIllegal, value); }

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
            //_Illegal = _IllegalRepository.Items.ToObservableCollection(); 
            //Illegal = (await _IllegalRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Illegal = _IllegalRepository.Items.ToObservableCollection();
            Illegal = _IllegalRepository.Items.ToObservableCollection();
            //_Illegal = (await _IllegalRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewIllegalCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewIllegalCommand;
        private ICommand _OnAddEditIllegalCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewIllegalCommand => _AddNewIllegalCommand
            ?? new LambdaCommand(OnAddNewIllegalCommandExecuted, CanAddNewIllegalCommandExecute);

        public ICommand OnAddEditIllegalCommand => _OnAddEditIllegalCommand
            ?? new LambdaCommand(OnAddEditIllegalCommandExecuted, CanAddNewIllegalCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewIllegalCommandExecute() => true;
        private bool CanAddEditIllegalCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditIllegalCommandExecuted()
        {
            var edit_Illegal = SelectedIllegal;
            if (!_UserDialog.Edit(edit_Illegal))
                return;
            _IllegalRepository.Update(edit_Illegal);
            IllegalView.Refresh();
        }

        private void OnAddNewIllegalCommandExecuted()
        {
            var new_Illegal = new Illegal();

            if (!_UserDialog.Edit(new_Illegal))
                return;
            //_IllegalRepository.Add(new_Illegal);
            Illegal.Add(_IllegalRepository.Add(new_Illegal));

            SelectedIllegal = new_Illegal;
        }

        #endregion

        #region Command RemoveIllegalCommand : Illegal - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveIllegalCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveIllegalCommand => _RemoveIllegalCommand
            ?? new LambdaCommand<Illegal>(OnRemoveIllegalCommandExecuted, CanRemoveIllegalCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveIllegalCommandExecute(Illegal p) => p != null || SelectedIllegal != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveIllegalCommandExecuted(Illegal p)
        {
            var Illegal_to_remove = p ?? SelectedIllegal;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить дежурство?", "Удаление дежурства"))
                return;

            _IllegalRepository.Remove(Illegal_to_remove.id);

            Illegal.Remove(Illegal_to_remove);
            if (ReferenceEquals(SelectedIllegal, Illegal_to_remove))
                SelectedIllegal = null;
        }

        #endregion

        public IllegalBaseViewModel(IRepository<Illegal> IllegalRepository, IUserDialog UserDialog)
        {
            _IllegalRepository = IllegalRepository;
            _UserDialog = UserDialog;
        }
    }
}
