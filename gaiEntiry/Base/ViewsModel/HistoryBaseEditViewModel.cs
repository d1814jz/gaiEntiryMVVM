using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class HistoryBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        private string _idWorkerData;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }

        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

        public IRepository<Rank> RankRepository = App.Services.GetService(typeof(IRepository<Rank>)) as IRepository<Rank>;
        public ObservableCollection<Rank> RanksView
        {
            get => RankRepository.Items.ToObservableCollection();
        }

        private Rank _SelectedRank;
        public Rank SelectedRank { get => _SelectedRank; set => Set(ref _SelectedRank, value); }

        public IRepository<Position> PositionRepository = App.Services.GetService(typeof(IRepository<Position>)) as IRepository<Position>;
        public ObservableCollection<Position> PositionsView
        {
            get => PositionRepository.Items.ToObservableCollection();
        }
        private Position _SelectedPosition;
        public Position SelectedPosition { get => _SelectedPosition; set => Set(ref _SelectedPosition, value); }

        private int _idWorker;
        public int idWorker { get => _idWorker; set => Set(ref _idWorker, value); }
        private int _idRank; 
        public int idRank { get => _idRank; set => Set(ref _idRank, value); }
        private int _idPosition;
        public int idPosition { get => _idPosition; set => Set(ref _idPosition, value); }
        private DateTime _DateHistory;
        public DateTime DateHistory { get => _DateHistory; set => Set(ref _DateHistory, value); }



        public HistoryBaseEditViewModel()
            : this(new History { })
        {
        }

        public HistoryBaseEditViewModel(History history)
        {
            idWorker = history.idWorker;
            idRank = history.idRank;
            idPosition = history.idPosition;
            DateHistory = history.Date;
            SelectedWorker = WorkersView.Where(u => u.id == idWorker).FirstOrDefault();
            SelectedRank = RanksView.Where(u => u.id == idRank).FirstOrDefault();
            SelectedPosition = PositionsView.Where(u => u.id == idPosition).FirstOrDefault();
        }
    }
}
