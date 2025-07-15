using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class AccidentMemberBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<Driver> DriverRepository = App.Services.GetService(typeof(IRepository<Driver>)) as IRepository<Driver>;
        public ObservableCollection<Driver> DriversView
        {
            get => DriverRepository.Items.ToObservableCollection();
        }

        private Driver _SelectedDriver;
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

        /*public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }

        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }
        */
        public IRepository<Auto> AutoRepository = App.Services.GetService(typeof(IRepository<Auto>)) as IRepository<Auto>;
        public ObservableCollection<Auto> AutosView
        {
            get => AutoRepository.Items.ToObservableCollection();
        }

        private Auto _SelectedAuto;
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

        public IRepository<Accident> AccidentRepository = App.Services.GetService(typeof(IRepository<Accident>)) as IRepository<Accident>;
        public ObservableCollection<Accident> AccidentsView
        {
            get => AccidentRepository.Items.ToObservableCollection();
        }

        private Accident _SelectedAccident;
        public Accident SelectedAccident { get => _SelectedAccident; set => Set(ref _SelectedAccident, value); }


        private string _Criminal;
        public string Criminal { get => _Criminal; set => Set(ref _Criminal, value); }


        public AccidentMemberBaseEditViewModel(AccidentMember AccidentMember)
        {
            Criminal = AccidentMember.Criminal;
            SelectedAccident = AccidentsView.Where(u => u.id == AccidentMember.idAccident).FirstOrDefault();
            SelectedDriver = DriversView.Where(u => u.id == AccidentMember.idDriver).FirstOrDefault();
            //SelectedWorker = WorkersView.Where(u => u.id == AccidentMember.idWorker).FirstOrDefault();
            SelectedAuto = AutosView.Where(u => u.id == AccidentMember.idAuto).FirstOrDefault();
        }
        public AccidentMemberBaseEditViewModel()
            : this(new AccidentMember {})
        {

        }
    }
}
