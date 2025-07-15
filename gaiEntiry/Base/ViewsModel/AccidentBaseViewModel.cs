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
    class AccidentBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Accident> _AccidentsRepository;
        public IUserDialog _UserDialog;


        private ObservableCollection<Accident> _Accidents;


        public ObservableCollection<Accident> Accidents
        {
            get => _Accidents;
            set
            {
                if (Set(ref _Accidents, value))
                {
                    _Accidents = value;
                    _AccidentsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AccidentsViewSource.View.Refresh();
                    //_Accidents = value;

                    OnPropertyChanged(nameof(AccidentsView));
                }
            }
        }

        private CollectionViewSource _AccidentsViewSource;

        public ICollectionView AccidentsView => _AccidentsViewSource?.View;

        #region SelectedAccident : Accident - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Accident _SelectedAccident;

        /// <summary>Выбранный автомобиль</summary>
        public Accident SelectedAccident { get => _SelectedAccident; set => Set(ref _SelectedAccident, value); }

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
            //_Accidents = _AccidentsRepository.Items.ToObservableCollection(); 
            //Accidents = (await _AccidentsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Accidents = _AccidentsRepository.Items.ToObservableCollection();
            Accidents = _AccidentsRepository.Items.ToObservableCollection();
            //_Accidents = (await _AccidentsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAccidentCommand - Добавление нового автомобиля

        /// <summary>Добавление автомобиля</summary>
        private ICommand _AddNewAccidentCommand;
        private ICommand _OnAddEditAccidentCommand;

        /// <summary>Добавление автомобиля</summary>
        public ICommand AddNewAccidentCommand => _AddNewAccidentCommand
            ?? new LambdaCommand(OnAddNewAccidentCommandExecuted, CanAddNewAccidentCommandExecute);

        public ICommand OnAddEditAccidentCommand => _OnAddEditAccidentCommand
            ?? new LambdaCommand(OnAddEditAccidentCommandExecuted, CanAddNewAccidentCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление автомобиля</summary>
        private bool CanAddNewAccidentCommandExecute() => true;
        private bool CanAddEditAccidentCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление автомобиля</summary>

        private void OnAddEditAccidentCommandExecuted()
        {
            var edit_Accident = SelectedAccident;
            if (!_UserDialog.Edit(edit_Accident))
                return;
            _AccidentsRepository.Update(edit_Accident);
            AccidentsView.Refresh();
            //Accidents.Add(_AccidentsRepository.Update(edit_Accident));
            //Accidents.Add(_AccidentsRepository.Add(SelectedAccident));
        }

        private void OnAddNewAccidentCommandExecuted()
        {
            var new_Accident = new Accident();

            if (!_UserDialog.Edit(new_Accident))
                return;
            //_AccidentsRepository.Add(new_Accident);
            Accidents.Add(_AccidentsRepository.Add(new_Accident));

            SelectedAccident = new_Accident;
        }

        #endregion

        #region Command RemoveAccidentCommand : Accident - Удаление автомобиля

        /// <summary>Удаление указанной автомобиля</summary>
        private ICommand _RemoveAccidentCommand;

        /// <summary>Удаление автомобиля</summary>
        public ICommand RemoveAccidentCommand => _RemoveAccidentCommand
            ?? new LambdaCommand<Accident>(OnRemoveAccidentCommandExecuted, CanRemoveAccidentCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление автомобиля</summary>
        private bool CanRemoveAccidentCommandExecute(Accident p) => p != null || SelectedAccident != null;

        /// <summary>Проверка возможности выполнения - Удалениеавтомобиля</summary>
        private void OnRemoveAccidentCommandExecuted(Accident p)
        {
            var Accident_to_remove = p ?? SelectedAccident;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить ДТП?", "Удаление ДТП"))
                return;

            _AccidentsRepository.Remove(Accident_to_remove.id);

            Accidents.Remove(Accident_to_remove);
            if (ReferenceEquals(SelectedAccident, Accident_to_remove))
                SelectedAccident = null;
        }

        #endregion

        public AccidentBaseViewModel(IRepository<Accident> AccidentsRepository, IUserDialog UserDialog)
        {
            _AccidentsRepository = AccidentsRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<Accident> Accidents
        {
            get { return _Accidents; }
            set
            {
                _Accidents = value;
                OnPropertyChanged(nameof(Accidents));
            }
        }*/
    }
}
