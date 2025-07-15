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
    class TypesOfIAPBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<TypesOfIAP> _TypesOfIAPRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<TypesOfIAP> _TypesOfIAP;


        public ObservableCollection<TypesOfIAP> TypesOfIAP
        {
            get => _TypesOfIAP;
            set
            {
                if (Set(ref _TypesOfIAP, value))
                {
                    _TypesOfIAP = value;
                    _TypesOfIAPViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _TypesOfIAPViewSource.View.Refresh();
                    //_TypesOfIAP = value;

                    OnPropertyChanged(nameof(TypesOfIAPView));
                }
            }
        }

        private CollectionViewSource _TypesOfIAPViewSource;

        public ICollectionView TypesOfIAPView => _TypesOfIAPViewSource?.View;

        #region SelectedTypesOfIAP : TypesOfIAP - Выбранный нарушение

        /// <summary>Выбранный нарушение</summary>
        private TypesOfIAP _SelectedTypesOfIAP;

        /// <summary>Выбранный нарушение</summary>
        public TypesOfIAP SelectedTypesOfIAP { get => _SelectedTypesOfIAP; set => Set(ref _SelectedTypesOfIAP, value); }

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
            //_TypesOfIAP = _TypesOfIAPRepository.Items.ToObservableCollection(); 
            //TypesOfIAP = (await _TypesOfIAPRepository.Items.ToArrayAsync()).ToObservableCollection();
            _TypesOfIAP = _TypesOfIAPRepository.Items.ToObservableCollection();
            TypesOfIAP = _TypesOfIAPRepository.Items.ToObservableCollection();
            //_TypesOfIAP = (await _TypesOfIAPRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewTypesOfIAPCommand - Добавление нового вида нарушения

        /// <summary>Добавление вида нарушения</summary>
        private ICommand _AddNewTypesOfIAPCommand;
        private ICommand _OnAddEditTypesOfIAPCommand;

        /// <summary>Добавление вида нарушения</summary>
        public ICommand AddNewTypesOfIAPCommand => _AddNewTypesOfIAPCommand
            ?? new LambdaCommand(OnAddNewTypesOfIAPCommandExecuted, CanAddNewTypesOfIAPCommandExecute);

        public ICommand OnAddEditTypesOfIAPCommand => _OnAddEditTypesOfIAPCommand
            ?? new LambdaCommand(OnAddEditTypesOfIAPCommandExecuted, CanAddNewTypesOfIAPCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление вида нарушения</summary>
        private bool CanAddNewTypesOfIAPCommandExecute() => true;
        private bool CanAddEditTypesOfIAPCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление вида нарушения</summary>

        private void OnAddEditTypesOfIAPCommandExecuted()
        {
            var edit_TypesOfIAP = SelectedTypesOfIAP;
            if (!_UserDialog.Edit(edit_TypesOfIAP))
                return;
            _TypesOfIAPRepository.Update(edit_TypesOfIAP);
            TypesOfIAPView.Refresh();
        }

        private void OnAddNewTypesOfIAPCommandExecuted()
        {
            var new_TypesOfIAP = new TypesOfIAP();

            if (!_UserDialog.Edit(new_TypesOfIAP))
                return;
            //_TypesOfIAPRepository.Add(new_TypesOfIAP);
            TypesOfIAP.Add(_TypesOfIAPRepository.Add(new_TypesOfIAP));

            SelectedTypesOfIAP = new_TypesOfIAP;
        }

        #endregion

        #region Command RemoveTypesOfIAPCommand : TypesOfIAP - Удаление вида нарушения

        /// <summary>Удаление указанной вида нарушения</summary>
        private ICommand _RemoveTypesOfIAPCommand;

        /// <summary>Удаление вида нарушения</summary>
        public ICommand RemoveTypesOfIAPCommand => _RemoveTypesOfIAPCommand
            ?? new LambdaCommand<TypesOfIAP>(OnRemoveTypesOfIAPCommandExecuted, CanRemoveTypesOfIAPCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление вида нарушения</summary>
        private bool CanRemoveTypesOfIAPCommandExecute(TypesOfIAP p) => p != null || SelectedTypesOfIAP != null;

        /// <summary>Проверка возможности выполнения - Удалениевида нарушения</summary>
        private void OnRemoveTypesOfIAPCommandExecuted(TypesOfIAP p)
        {
            var TypesOfIAP_to_remove = p ?? SelectedTypesOfIAP;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить тип поощрения/взыскания?", "Удаление типа"))
                return;

            _TypesOfIAPRepository.Remove(TypesOfIAP_to_remove.id);

            TypesOfIAP.Remove(TypesOfIAP_to_remove);
            if (ReferenceEquals(SelectedTypesOfIAP, TypesOfIAP_to_remove))
                SelectedTypesOfIAP = null;
        }

        #endregion

        public TypesOfIAPBaseViewModel(IRepository<TypesOfIAP> TypesOfIAPRepository, IUserDialog UserDialog)
        {
            _TypesOfIAPRepository = TypesOfIAPRepository;
            _UserDialog = UserDialog;
        }
    }
}
