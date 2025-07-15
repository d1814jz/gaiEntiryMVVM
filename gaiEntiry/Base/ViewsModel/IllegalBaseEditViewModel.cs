using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class IllegalBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<IllegalType> IllegalTypeRepository = App.Services.GetService(typeof(IRepository<IllegalType>)) as IRepository<IllegalType>;
        public ObservableCollection<IllegalType> IllegalTypesView
        {
            get => IllegalTypeRepository.Items.ToObservableCollection();
        }
        private IllegalType _SelectedIllegalType;
        public IllegalType SelectedIllegalType { get => _SelectedIllegalType; set => Set(ref _SelectedIllegalType, value); }

        public IRepository<Duty> DutyRepository = App.Services.GetService(typeof(IRepository<Duty>)) as IRepository<Duty>;
        public ObservableCollection<Duty> DutysView
        {
            get => DutyRepository.Items.ToObservableCollection();
        }
        private Duty _SelectedDuty;
        public Duty SelectedDuty { get => _SelectedDuty; set => Set(ref _SelectedDuty, value); }

        public IRepository<Auto> AutoRepository = App.Services.GetService(typeof(IRepository<Auto>)) as IRepository<Auto>;
        public ObservableCollection<Auto> AutosView
        {
            get => AutoRepository.Items.ToObservableCollection();
        }
        private Auto _SelectedAuto;
        public Auto SelectedAuto { get => _SelectedAuto; set => Set(ref _SelectedAuto, value); }

        public IRepository<Driver> DriverRepository = App.Services.GetService(typeof(IRepository<Driver>)) as IRepository<Driver>;
        public ObservableCollection<Driver> DriversView
        {
            get => DriverRepository.Items.ToObservableCollection();
        }
        private Driver _SelectedDriver;
        public Driver SelectedDriver { get => _SelectedDriver; set => Set(ref _SelectedDriver, value); }

        private int _idIllegalType;
        public int idIllegalType { get => _idIllegalType; set => Set(ref _idIllegalType, value); }
        private int _idDuty;
        public int idDuty { get => _idDuty; set => Set(ref _idDuty, value); }
        private int _idAuto;
        public int idAuto { get => _idAuto; set => Set(ref _idAuto, value); }
        private int _idDriver;
        public int idDriver { get => _idDriver; set => Set(ref _idDriver, value); }
        private string _Place;
        public string Place { get => _Place; set => Set(ref _Place, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }


        public IllegalBaseEditViewModel() 
            :this(new Illegal { })
        {
        }

        public IllegalBaseEditViewModel(Illegal illegal)
        {
            SelectedIllegalType = IllegalTypesView.Where(u => u.id == illegal.idIllegalType).FirstOrDefault();
            SelectedDuty = DutysView.Where(u => u.id == illegal.idDuty).FirstOrDefault();
            SelectedAuto = AutosView.Where(u => u.id == illegal.idAuto).FirstOrDefault();
            SelectedDriver = DriversView.Where(u => u.id == illegal.idDriver).FirstOrDefault();
            /*idIllegalType = illegal.idIllegalType;
            idDuty = illegal.idDuty;
            idAuto = illegal.idAuto;
            idDriver = illegal.idDriver;*/
            Place = illegal.Place;
            Description = illegal.Description;

        }


    }
}
