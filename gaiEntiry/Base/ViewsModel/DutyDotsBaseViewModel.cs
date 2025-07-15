using MathCore.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using MathCore.WPF.ViewModels;
using gaiEntiry.Base.Service;
using MathCore.ViewModels;
using System.Windows;
using gaiEntiry.Base.Repository;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyDotsBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<DutyDots> _DutyDotssRepository;
        public IUserDialog _UserDialog;

        //_DutyDotssRepository.Items.ToObservableCollection();
        /*
         public List<Driver> AllDrivers
        {
            get { return allDrivers; }
            set
            {
                allDrivers = value;
                NotifyPropertyChanged("AllDrivers");
            }
        }
         */

        private ObservableCollection<DutyDots> _DutyDotss;


        public ObservableCollection<DutyDots> DutyDotss
        {
            get => _DutyDotss;
            set
            {
                if (Set(ref _DutyDotss, value))
                {
                    _DutyDotss = value;
                    _DutyDotssViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _DutyDotssViewSource.View.Refresh();
                    //_DutyDotss = value;

                    OnPropertyChanged(nameof(DutyDotssView));
                }
            }
        }

        private CollectionViewSource _DutyDotssViewSource;

        public ICollectionView DutyDotssView => _DutyDotssViewSource?.View;

        #region SelectedDutyDots : DutyDots - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private DutyDots _SelectedDutyDots;

        /// <summary>Выбранный автомобиль</summary>
        public DutyDots SelectedDutyDots { get => _SelectedDutyDots; set => Set(ref _SelectedDutyDots, value); }

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
            //_DutyDotss = _DutyDotssRepository.Items.ToObservableCollection(); 
            //DutyDotss = (await _DutyDotssRepository.Items.ToArrayAsync()).ToObservableCollection();
            _DutyDotss = _DutyDotssRepository.Items.ToObservableCollection();
            DutyDotss = _DutyDotssRepository.Items.ToObservableCollection();
            //_DutyDotss = (await _DutyDotssRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewDutyDotsCommand - Добавление нового автомобиля

        /// <summary>Добавление автомобиля</summary>
        private ICommand _AddNewDutyDotsCommand;
        private ICommand _OnAddEditDutyDotsCommand;

        /// <summary>Добавление автомобиля</summary>
        public ICommand AddNewDutyDotsCommand => _AddNewDutyDotsCommand
            ?? new LambdaCommand(OnAddNewDutyDotsCommandExecuted, CanAddNewDutyDotsCommandExecute);

        public ICommand OnAddEditDutyDotsCommand => _OnAddEditDutyDotsCommand
            ?? new LambdaCommand(OnAddEditDutyDotsCommandExecuted, CanAddNewDutyDotsCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление автомобиля</summary>
        private bool CanAddNewDutyDotsCommandExecute() => true;
        private bool CanAddEditDutyDotsCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление автомобиля</summary>

        private void OnAddEditDutyDotsCommandExecuted()
        {
            var edit_DutyDots = SelectedDutyDots;
            if (!_UserDialog.Edit(edit_DutyDots))
                return;
            _DutyDotssRepository.Update(edit_DutyDots);
            DutyDotssView.Refresh();
            //DutyDotss.Add(_DutyDotssRepository.Update(edit_DutyDots));
            //DutyDotss.Add(_DutyDotssRepository.Add(SelectedDutyDots));
        }

        private void OnAddNewDutyDotsCommandExecuted()
        {
            var new_DutyDots = new DutyDots();

            if (!_UserDialog.Edit(new_DutyDots))
                return;
            //_DutyDotssRepository.Add(new_DutyDots);
            DutyDotss.Add(_DutyDotssRepository.Add(new_DutyDots));

            SelectedDutyDots = new_DutyDots;
        }

        #endregion

        #region Command RemoveDutyDotsCommand : DutyDots - Удаление автомобиля

        /// <summary>Удаление указанной автомобиля</summary>
        private ICommand _RemoveDutyDotsCommand;

        /// <summary>Удаление автомобиля</summary>
        public ICommand RemoveDutyDotsCommand => _RemoveDutyDotsCommand
            ?? new LambdaCommand<DutyDots>(OnRemoveDutyDotsCommandExecuted, CanRemoveDutyDotsCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление автомобиля</summary>
        private bool CanRemoveDutyDotsCommandExecute(DutyDots p) => p != null || SelectedDutyDots != null;

        /// <summary>Проверка возможности выполнения - Удалениеавтомобиля</summary>
        private void OnRemoveDutyDotsCommandExecuted(DutyDots p)
        {
            var DutyDots_to_remove = p ?? SelectedDutyDots;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить точку дежурства?", "Удаление точки дежурства"))
                return;

            _DutyDotssRepository.Remove(DutyDots_to_remove.id);

            DutyDotss.Remove(DutyDots_to_remove);
            if (ReferenceEquals(SelectedDutyDots, DutyDots_to_remove))
                SelectedDutyDots = null;
        }



        #endregion

        public DutyDotsBaseViewModel(IRepository<DutyDots> DutyDotssRepository, IUserDialog UserDialog)
        {
            _DutyDotssRepository = DutyDotssRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<DutyDots> DutyDotss
        {
            get { return _DutyDotss; }
            set
            {
                _DutyDotss = value;
                OnPropertyChanged(nameof(DutyDotss));
            }
        }*/
    }
}
