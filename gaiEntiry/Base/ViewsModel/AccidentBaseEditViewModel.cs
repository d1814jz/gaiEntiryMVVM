using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class AccidentBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        //public int AccidentId;
        public IRepository<Street> StreetRepository = App.Services.GetService(typeof(IRepository<Street>)) as IRepository<Street>;
        public ObservableCollection<Street> StreetsView
        {
            get => StreetRepository.Items.ToObservableCollection();
        }

        private Street _SelectedStreet;
        public Street SelectedStreet { get => _SelectedStreet; set => Set(ref _SelectedStreet, value); }

        public IRepository<Worker> WorkerRepository = App.Services.GetService(typeof(IRepository<Worker>)) as IRepository<Worker>;
        public ObservableCollection<Worker> WorkersView
        {
            get => WorkerRepository.Items.ToObservableCollection();
        }

        private Worker _SelectedWorker;
        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }


        private string _Place;
        public string Place { get => _Place; set => Set(ref _Place, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }


        public AccidentBaseEditViewModel(Accident accident)
        {
            SelectedStreet = StreetsView.Where(u => u.id == accident.idStreet).FirstOrDefault();
            SelectedWorker = WorkersView.Where(u => u.id == accident.idWorker).FirstOrDefault();
            Place = accident.Place;
            Description = accident.Description;
            Date = accident.Date;
        }
        public AccidentBaseEditViewModel()
            : this(new Accident {})
        {

        }
    }
}
