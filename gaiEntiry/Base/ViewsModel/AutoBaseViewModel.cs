﻿using MathCore.WPF.Commands;
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
    class AutoBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Auto> _AutosRepository;
        public IUserDialog _UserDialog;

        //_AutosRepository.Items.ToObservableCollection();
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
        
        private ObservableCollection<Auto> _Autos;


        public ObservableCollection<Auto> Autos
        {
            get => _Autos;
            set
            {
                if (Set(ref _Autos, value))
                {
                    _Autos = value;
                    _AutosViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AutosViewSource.View.Refresh();
                    //_Autos = value;

                    OnPropertyChanged(nameof(AutosView));
                }
            }
        }

        private CollectionViewSource _AutosViewSource;

        public ICollectionView AutosView => _AutosViewSource?.View;

        #region SelectedAuto : Auto - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Auto _SelectedAuto;

        /// <summary>Выбранный автомобиль</summary>
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

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
            //_Autos = _AutosRepository.Items.ToObservableCollection(); 
            //Autos = (await _AutosRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Autos = _AutosRepository.Items.ToObservableCollection();
            Autos = _AutosRepository.Items.ToObservableCollection(); 
            //_Autos = (await _AutosRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAutoCommand - Добавление нового автомобиля

        /// <summary>Добавление автомобиля</summary>
        private ICommand _AddNewAutoCommand;
        private ICommand _OnAddEditAutoCommand;

        /// <summary>Добавление автомобиля</summary>
        public ICommand AddNewAutoCommand => _AddNewAutoCommand
            ?? new LambdaCommand(OnAddNewAutoCommandExecuted, CanAddNewAutoCommandExecute);

        public ICommand OnAddEditAutoCommand => _OnAddEditAutoCommand
            ?? new LambdaCommand(OnAddEditAutoCommandExecuted, CanAddNewAutoCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление автомобиля</summary>
        private bool CanAddNewAutoCommandExecute() => true;
        private bool CanAddEditAutoCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление автомобиля</summary>

        private void OnAddEditAutoCommandExecuted()
        {
            var edit_auto = SelectedAuto;
            if (!_UserDialog.Edit(edit_auto))
                return;
            _AutosRepository.Update(edit_auto);
            AutosView.Refresh();
            //Autos.Add(_AutosRepository.Update(edit_auto));
            //Autos.Add(_AutosRepository.Add(SelectedAuto));
        }

        private void OnAddNewAutoCommandExecuted()
        {
            var new_Auto = new Auto();

            if (!_UserDialog.Edit(new_Auto))
                return;
            //_AutosRepository.Add(new_Auto);
            Autos.Add(_AutosRepository.Add(new_Auto));

            SelectedAuto = new_Auto;
        }

        #endregion

        #region Command RemoveAutoCommand : Auto - Удаление автомобиля

        /// <summary>Удаление указанной автомобиля</summary>
        private ICommand _RemoveAutoCommand;

        /// <summary>Удаление автомобиля</summary>
        public ICommand RemoveAutoCommand => _RemoveAutoCommand
            ?? new LambdaCommand<Auto>(OnRemoveAutoCommandExecuted, CanRemoveAutoCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление автомобиля</summary>
        private bool CanRemoveAutoCommandExecute(Auto p) => p != null || SelectedAuto != null;

        /// <summary>Проверка возможности выполнения - Удалениеавтомобиля</summary>
        private void OnRemoveAutoCommandExecuted(Auto p)
        {
            var Auto_to_remove = p ?? SelectedAuto;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить автомобиль {Auto_to_remove.Brand} {Auto_to_remove.Model}?", "Удаление автомобиля"))
                return;

            _AutosRepository.Remove(Auto_to_remove.id);

            Autos.Remove(Auto_to_remove);
            if (ReferenceEquals(SelectedAuto, Auto_to_remove))
                SelectedAuto = null;
        }

        #endregion

        public AutoBaseViewModel(IRepository<Auto> AutosRepository, IUserDialog UserDialog)
        {
            _AutosRepository = AutosRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Auto> Autos
        {
            get { return _Autos; }
            set
            {
                _Autos = value;
                OnPropertyChanged(nameof(Autos));
            }
        }*/
    }
}
