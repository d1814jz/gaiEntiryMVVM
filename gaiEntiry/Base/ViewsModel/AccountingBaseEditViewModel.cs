using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class AccountingBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        private string _idWorkerData;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }

        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

        public IRepository<Driver> DriverRepository = App.Services.GetService(typeof(IRepository<Driver>)) as IRepository<Driver>;
        private string _idDriverData;
        public ObservableCollection<Driver> DriversView
        {
            get => DriverRepository.Items.ToObservableCollection();
        }

        private Driver _SelectedDriver;
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

        public IRepository<Auto> AutoRepository = App.Services.GetService(typeof(IRepository<Auto>)) as IRepository<Auto>;
        private string _idAutoData;
        public ObservableCollection<Auto> AutosView
        {
            get => AutoRepository.Items.ToObservableCollection();
        }

        private Auto _SelectedAuto;
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

        private int _idWorker;
        public int idWorker { get => _idWorker; set => Set(ref _idWorker, value); }
        private int _idDriver;
        public int idDriver { get => _idDriver; set => Set(ref _idDriver, value); }
        private int _idAuto;
        public int idAuto { get => _idAuto; set => Set(ref _idAuto, value); }
        private string _Number;
        public string Number { get => _Number; set => Set(ref _Number, value); }
        private string _Color;
        public string Color { get => _Color; set => Set(ref _Color, value); }
        private DateTime _FirstDate;
        public DateTime FirstDate { get => _FirstDate; set => Set(ref _FirstDate, value); }
        private DateTime _LastDate;
        public DateTime LastDate { get => _LastDate; set => Set(ref _LastDate, value); }

        public AccountingBaseEditViewModel(Accounting accounting)
        {
            idWorker = accounting.idWorker;
            idDriver = accounting.idDriver;
            idAuto = accounting.idAuto;
            Number = accounting.Number;
            Color = accounting.Color;
            FirstDate = accounting.FirstDate;
            //LastDate = (DateTime)accounting.LastDate;
            if (accounting.LastDate.ToString() != string.Empty)
                    LastDate = (DateTime)accounting.LastDate;
            SelectedAuto = AutosView.Where(u => u.id == idAuto).FirstOrDefault();
            SelectedDriver = DriversView.Where(u => u.id == idDriver).FirstOrDefault();
            SelectedWorker = WorkersView.Where(u => u.id == idWorker).FirstOrDefault();


        }
        public AccountingBaseEditViewModel()
            :this(new Accounting { })
        {

        }
    }
}
