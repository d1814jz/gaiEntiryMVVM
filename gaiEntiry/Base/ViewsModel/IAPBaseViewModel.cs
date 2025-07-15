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
    class IAPBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<IAP> _IAPRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<IAP> _IAP;


        public ObservableCollection<IAP> IAP
        {
            get => _IAP;
            set
            {
                if (Set(ref _IAP, value))
                {
                    _IAP = value;
                    _IAPViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _IAPViewSource.View.Refresh();
                    //_IAP = value;

                    OnPropertyChanged(nameof(IAPView));
                }
            }
        }

        private CollectionViewSource _IAPViewSource;

        public ICollectionView IAPView => _IAPViewSource?.View;

        #region SelectedIAP : IAP - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private IAP _SelectedIAP;

        /// <summary>Выбранный нарушение</summary>
        public IAP SelectedIAP { get => _SelectedIAP; set => Set(ref _SelectedIAP, value); }

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
            //_IAP = _IAPRepository.Items.ToObservableCollection(); 
            //IAP = (await _IAPRepository.Items.ToArrayAsync()).ToObservableCollection();
            _IAP = _IAPRepository.Items.ToObservableCollection();
            IAP = _IAPRepository.Items.ToObservableCollection();
            //_IAP = (await _IAPRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewIAPCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewIAPCommand;
        private ICommand _OnAddEditIAPCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewIAPCommand => _AddNewIAPCommand
            ?? new LambdaCommand(OnAddNewIAPCommandExecuted, CanAddNewIAPCommandExecute);

        public ICommand OnAddEditIAPCommand => _OnAddEditIAPCommand
            ?? new LambdaCommand(OnAddEditIAPCommandExecuted, CanAddNewIAPCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewIAPCommandExecute() => true;
        private bool CanAddEditIAPCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditIAPCommandExecuted()
        {
            var edit_IAP = SelectedIAP;
            if (!_UserDialog.Edit(edit_IAP))
                return;
            _IAPRepository.Update(edit_IAP);
            IAPView.Refresh();
        }

        private void OnAddNewIAPCommandExecuted()
        {
            var new_IAP = new IAP();

            if (!_UserDialog.Edit(new_IAP))
                return;
            //_IAPRepository.Add(new_IAP);
            IAP.Add(_IAPRepository.Add(new_IAP));

            SelectedIAP = new_IAP;
        }

        #endregion

        #region Command RemoveIAPCommand : IAP - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveIAPCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveIAPCommand => _RemoveIAPCommand
            ?? new LambdaCommand<IAP>(OnRemoveIAPCommandExecuted, CanRemoveIAPCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveIAPCommandExecute(IAP p) => p != null || SelectedIAP != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveIAPCommandExecuted(IAP p)
        {
            var IAP_to_remove = p ?? SelectedIAP;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить запись?", "Удаление записи"))
                return;

            _IAPRepository.Remove(IAP_to_remove.id);

            IAP.Remove(IAP_to_remove);
            if (ReferenceEquals(SelectedIAP, IAP_to_remove))
                SelectedIAP = null;
        }

        #endregion

        public IAPBaseViewModel(IRepository<IAP> IAPRepository, IUserDialog UserDialog)
        {
            _IAPRepository = IAPRepository;
            _UserDialog = UserDialog;
        }
    }
}
