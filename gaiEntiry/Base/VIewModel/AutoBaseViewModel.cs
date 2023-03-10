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

namespace gaiEntiry.Base.VIewModel
{
    class AutoBaseViewModel
    {
        private readonly IRepository<Auto> _AutosRepository;
        private readonly IUserDialog _UserDialog;

        private ObservableCollection<Auto> _Autos;

        public ObservableCollection<Auto> Autos
        {
            get => _Autos;
            set
            {
                if (Set(ref _Autos, value))
                {
                    _AutosViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AutosViewSource.View.Refresh();

                    OnPropertyChanged(nameof(AutosView));
                }
            }
        }

        private bool Set(ref ObservableCollection<Auto> autos, ObservableCollection<Auto> value)
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        private CollectionViewSource _AutosViewSource;

        public ICollectionView AutosView => _AutosViewSource?.View;

        #region SelectedAuto : Auto - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private Auto _SelectedAuto;

        /// <summary>Выбранный автомобиль</summary>
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

        private void Set(ref Auto selectedAuto, Auto value)
        {
            throw new NotImplementedException();
        }


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
            //Autos = (await _AutosRepository.Items.ToArrayAsync()).ToObservableCollection();
            Autos = new ObservableCollection<Auto>( _AutosRepository.Items.ToObservableCollection());
        }

        #endregion

        #region Command AddNewAutoCommand - Добавление новой книги

        /// <summary>Добавление новой книги</summary>
        private ICommand _AddNewAutoCommand;

        /// <summary>Добавление новой книги</summary>
        public ICommand AddNewAutoCommand => _AddNewAutoCommand
            ?? new LambdaCommand(OnAddNewAutoCommandExecuted, CanAddNewAutoCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление новой книги</summary>
        private bool CanAddNewAutoCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление новой книги</summary>
        private void OnAddNewAutoCommandExecuted()
        {
            var new_Auto = new Auto();

            if (!_UserDialog.Edit(new_Auto))
                return;

            _Autos.Add(_AutosRepository.Add(new_Auto));

            SelectedAuto = new_Auto;
        }

        #endregion

        #region Command RemoveAutoCommand : Auto - Удаление указанной книги

        /// <summary>Удаление указанной книги</summary>
        private ICommand _RemoveAutoCommand;

        /// <summary>Удаление указанной книги</summary>
        public ICommand RemoveAutoCommand => _RemoveAutoCommand
            ?? new LambdaCommand<Auto>(OnRemoveAutoCommandExecuted, CanRemoveAutoCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление указанной книги</summary>
        private bool CanRemoveAutoCommandExecute(Auto p) => p != null || SelectedAuto != null;

        /// <summary>Проверка возможности выполнения - Удаление указанной книги</summary>
        private void OnRemoveAutoCommandExecuted(Auto p)
        {
            var Auto_to_remove = p ?? SelectedAuto;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить автомобиль {Auto_to_remove.Model} {Auto_to_remove.Brand}?", "Удаление автомобиля"))
                return;

            _AutosRepository.Remove(Auto_to_remove.id);

            Autos.Remove(Auto_to_remove);
            if (ReferenceEquals(SelectedAuto, Auto_to_remove))
                SelectedAuto = null;
        }

        #endregion

        /*public AutoBaseViewModel(IRepository<Auto> AutosRepository, IUserDialog UserDialog)
        {
            _AutosRepository = AutosRepository;
            _UserDialog = UserDialog;
        }*/

    }
}
