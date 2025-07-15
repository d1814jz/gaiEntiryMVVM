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
    class AccidentMemberBaseViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<AccidentMember> _AccidentMembersRepository;
        public IUserDialog _UserDialog;

        //_AccidentMembersRepository.Items.ToObservableCollection();
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

        private ObservableCollection<AccidentMember> _AccidentMembers;


        public ObservableCollection<AccidentMember> AccidentMembers
        {
            get => _AccidentMembers;
            set
            {
                if (Set(ref _AccidentMembers, value))
                {
                    _AccidentMembers = value;
                    _AccidentMembersViewSource = new CollectionViewSource
                    {
                        Source = value,
                    };

                    _AccidentMembersViewSource.View.Refresh();
                    //_AccidentMembers = value;

                    OnPropertyChanged(nameof(AccidentMembersView));
                }
            }
        }

        private CollectionViewSource _AccidentMembersViewSource;

        public ICollectionView AccidentMembersView => _AccidentMembersViewSource?.View;

        #region SelectedAccidentMember : AccidentMember - Выбранный автомобиль

        /// <summary>Выбранный автомобиль</summary>
        private AccidentMember _SelectedAccidentMember;

        /// <summary>Выбранный автомобиль</summary>
        public AccidentMember SelectedAccidentMember { get => _SelectedAccidentMember; set => Set(ref _SelectedAccidentMember, value); }

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
            //_AccidentMembers = _AccidentMembersRepository.Items.ToObservableCollection(); 
            //AccidentMembers = (await _AccidentMembersRepository.Items.ToArrayAsync()).ToObservableCollection();
            _AccidentMembers = _AccidentMembersRepository.Items.ToObservableCollection();
            AccidentMembers = _AccidentMembersRepository.Items.ToObservableCollection();
            //_AccidentMembers = (await _AccidentMembersRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewAccidentMemberCommand - Добавление нового автомобиля

        /// <summary>Добавление автомобиля</summary>
        private ICommand _AddNewAccidentMemberCommand;
        private ICommand _OnAddEditAccidentMemberCommand;

        /// <summary>Добавление автомобиля</summary>
        public ICommand AddNewAccidentMemberCommand => _AddNewAccidentMemberCommand
            ?? new LambdaCommand(OnAddNewAccidentMemberCommandExecuted, CanAddNewAccidentMemberCommandExecute);

        public ICommand OnAddEditAccidentMemberCommand => _OnAddEditAccidentMemberCommand
            ?? new LambdaCommand(OnAddEditAccidentMemberCommandExecuted, CanAddNewAccidentMemberCommandExecute);

        /// <summary>Проверка возможности выполнения - Добавление автомобиля</summary>
        private bool CanAddNewAccidentMemberCommandExecute() => true;
        private bool CanAddEditAccidentMemberCommandExecute() => true;

        /// <summary>Логика выполнения - Добавление автомобиля</summary>

        private void OnAddEditAccidentMemberCommandExecuted()
        {
            var edit_AccidentMember = SelectedAccidentMember;
            if (!_UserDialog.Edit(edit_AccidentMember))
                return;
            _AccidentMembersRepository.Update(edit_AccidentMember);
            AccidentMembersView.Refresh();
            //AccidentMembers.Add(_AccidentMembersRepository.Update(edit_AccidentMember));
            //AccidentMembers.Add(_AccidentMembersRepository.Add(SelectedAccidentMember));
        }

        private void OnAddNewAccidentMemberCommandExecuted()
        {
            var new_AccidentMember = new AccidentMember();

            if (!_UserDialog.Edit(new_AccidentMember))
                return;
            //_AccidentMembersRepository.Add(new_AccidentMember);
            AccidentMembers.Add(_AccidentMembersRepository.Add(new_AccidentMember));

            SelectedAccidentMember = new_AccidentMember;
        }

        #endregion

        #region Command RemoveAccidentMemberCommand : AccidentMember - Удаление автомобиля

        /// <summary>Удаление указанной автомобиля</summary>
        private ICommand _RemoveAccidentMemberCommand;

        /// <summary>Удаление автомобиля</summary>
        public ICommand RemoveAccidentMemberCommand => _RemoveAccidentMemberCommand
            ?? new LambdaCommand<AccidentMember>(OnRemoveAccidentMemberCommandExecuted, CanRemoveAccidentMemberCommandExecute);

        /// <summary>Проверка возможности выполнения - Удаление автомобиля</summary>
        private bool CanRemoveAccidentMemberCommandExecute(AccidentMember p) => p != null || SelectedAccidentMember != null;

        /// <summary>Проверка возможности выполнения - Удалениеавтомобиля</summary>
        private void OnRemoveAccidentMemberCommandExecuted(AccidentMember p)
        {
            var AccidentMember_to_remove = p ?? SelectedAccidentMember;

            if (!_UserDialog.ConfirmWarning($"Вы хотите удалить участника ДТП {AccidentMember_to_remove.Driver.LastName} {AccidentMember_to_remove.Driver.FirstName} {AccidentMember_to_remove.Driver.Surname}?", "Удаление автомобиля"))
                return;

            _AccidentMembersRepository.Remove(AccidentMember_to_remove.id);

            AccidentMembers.Remove(AccidentMember_to_remove);
            if (ReferenceEquals(SelectedAccidentMember, AccidentMember_to_remove))
                SelectedAccidentMember = null;
        }

        #endregion

        public AccidentMemberBaseViewModel(IRepository<AccidentMember> AccidentMembersRepository, IUserDialog UserDialog)
        {
            _AccidentMembersRepository = AccidentMembersRepository;
            _UserDialog = UserDialog;
        }




        /*public ObservableCollection<AccidentMember> AccidentMembers
        {
            get { return _AccidentMembers; }
            set
            {
                _AccidentMembers = value;
                OnPropertyChanged(nameof(AccidentMembers));
            }
        }*/
    }
}
