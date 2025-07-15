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
    class PositionBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Position> _PositionsRepository;
        public IUserDialog _UserDialog;

        private ObservableCollection<Position> _Positions;


        public ObservableCollection<Position> Positions
        {
            get => _Positions;
            set
            {
                if (Set(ref _Positions, value))
                {
                    _Positions = value;
                    _PositionsViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _PositionsViewSource.View.Refresh();
                    //_Positions = value;

                    OnPropertyChanged(nameof(PositionsView));
                }
            }
        }

        private CollectionViewSource _PositionsViewSource;

        public ICollectionView PositionsView => _PositionsViewSource?.View;

        #region SelectedPosition : Position - Выбранный водитель

        /// <summary>Выбранный водитель</summary>
        private Position _SelectedPosition;

        /// <summary>Выбранный водитель</summary>
        public Position SelectedPosition { get => _SelectedPosition; set => Set(ref _SelectedPosition, value); }

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
            //_Positions = _PositionsRepository.Items.ToObservableCollection(); 
            //Positions = (await _PositionsRepository.Items.ToArrayAsync()).ToObservableCollection();
            _Positions = _PositionsRepository.Items.ToObservableCollection();
            Positions = _PositionsRepository.Items.ToObservableCollection();
            //_Positions = (await _PositionsRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewPositionCommand - Добавление нового водителя

        /// <summary>Добавление водителя</summary>
        private ICommand _AddNewPositionCommand;
        private ICommand _OnAddEditPositionCommand;

        /// <summary>Добавление водителя</summary>
        public ICommand AddNewPositionCommand => _AddNewPositionCommand
            ?? new LambdaCommand(OnAddNewPositionCommandExecuted, CanAddNewPositionCommandExecute);

        public ICommand OnAddEditPositionCommand => _OnAddEditPositionCommand
            ?? new LambdaCommand(OnAddEditPositionCommandExecuted, CanAddNewPositionCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление водителя</summary>
        private bool CanAddNewPositionCommandExecute() => true;
        private bool CanAddEditPositionCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление водителя</summary>

        private void OnAddEditPositionCommandExecuted()
        {
            var edit_Position = SelectedPosition;
            if (!_UserDialog.Edit(edit_Position))
                return;
            _PositionsRepository.Update(edit_Position);
            PositionsView.Refresh();
        }

        private void OnAddNewPositionCommandExecuted()
        {
            var new_Position = new Position();

            if (!_UserDialog.Edit(new_Position))
                return;
            //_PositionsRepository.Add(new_Position);
            Positions.Add(_PositionsRepository.Add(new_Position));

            SelectedPosition = new_Position;
        }

        #endregion

        #region Command RemovePositionCommand : Position - Удаление водителя

        /// <summary>Удаление указанной водителя</summary>
        private ICommand _RemovePositionCommand;

        /// <summary>Удаление водителя</summary>
        public ICommand RemovePositionCommand => _RemovePositionCommand
            ?? new LambdaCommand<Position>(OnRemovePositionCommandExecuted, CanRemovePositionCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление водителя</summary>
        private bool CanRemovePositionCommandExecute(Position p) => p != null || SelectedPosition != null;

        /// <summary>Проверка возможности выполнения - Удалениеводителя</summary>
        private void OnRemovePositionCommandExecuted(Position p)
        {
            var Position_to_remove = p ?? SelectedPosition;

            if (!_UserDialog.ConfirmWarning($"Вы убрать должность?", "Удаление должности"))
                return;

            _PositionsRepository.Remove(Position_to_remove.id);

            Positions.Remove(Position_to_remove);
            if (ReferenceEquals(SelectedPosition, Position_to_remove))
                SelectedPosition = null;
        }

        #endregion

        public PositionBaseViewModel(IRepository<Position> PositionsRepository, IUserDialog UserDialog)
        {
            _PositionsRepository = PositionsRepository;
            _UserDialog = UserDialog;
        }
    }

}
