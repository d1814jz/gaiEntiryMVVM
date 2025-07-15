using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }
        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }

         public IRepository<ServiceCar> ServiceCarRepository = App.Services.GetService(typeof(IRepository<ServiceCar>)) as IRepository<ServiceCar>;
        public ObservableCollection<ServiceCar> ServiceCarsView
        {
            get => ServiceCarRepository.Items.ToObservableCollection();
        }
        private ServiceCar _SelectedServiceCar;
        public ServiceCar SelectedServiceCar { get => _SelectedServiceCar; set => Set(ref _SelectedServiceCar, value); }

        public IRepository<DutyDots> DutyDotsRepository = App.Services.GetService(typeof(IRepository<DutyDots>)) as IRepository<DutyDots>;
        public ObservableCollection<DutyDots> DutyDotssView
        {
            get => DutyDotsRepository.Items.ToObservableCollection();
        }
        private DutyDots _SelectedDutyDots;
        public DutyDots SelectedDutyDots { get => _SelectedDutyDots; set => Set(ref _SelectedDutyDots, value); }

        private int _idWorker;
        public int idWorker { get => _idWorker; set => Set(ref _idWorker, value); }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        private string _Place;
        public string Place { get => _Place; set => Set(ref _Place, value); }

        public DutyBaseEditViewModel(Duty duty)
        {
            SelectedWorker = WorkersView.Where(u => u.id == duty.idWorker).FirstOrDefault();
            SelectedDutyDots = DutyDotssView.Where(u => u.id == duty.idDutyDots).FirstOrDefault();
            SelectedServiceCar = ServiceCarsView.Where(u => u.id == duty.idServiceCar).FirstOrDefault();
            Date = duty.Date;
        }

        public DutyBaseEditViewModel()
            : this(new Duty { })
        {

        }
    }
}
