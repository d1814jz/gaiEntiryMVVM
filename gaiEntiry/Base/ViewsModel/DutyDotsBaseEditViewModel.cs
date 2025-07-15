using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyDotsBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        //public int DutyDotsId;
        public IRepository<DutyDotsType> DutyDotsTypeRepository = App.Services.GetService(typeof(IRepository<DutyDotsType>)) as IRepository<DutyDotsType>;
        public ObservableCollection<DutyDotsType> DutyDotsTypesView
        {
            get => DutyDotsTypeRepository.Items.ToObservableCollection();
        }

        private DutyDotsType _SelectedDutyDotsType;
        public DutyDotsType SelectedDutyDotsType { get => _SelectedDutyDotsType; set => Set(ref _SelectedDutyDotsType, value); }

        public IRepository<District> DistrictRepository = App.Services.GetService(typeof(IRepository<District>)) as IRepository<District>;
        public ObservableCollection<District> DistrictsView
        {
            get => DistrictRepository.Items.ToObservableCollection();
        }

        private District _SelectedDistrict;
        public District SelectedDistrict { get => _SelectedDistrict; set => Set(ref _SelectedDistrict, value); }

        public IRepository<Street> FirstPlaceRepository = App.Services.GetService(typeof(IRepository<Street>)) as IRepository<Street>;
        public ObservableCollection<Street> FirstPlacesView
        {
            get => FirstPlaceRepository.Items.ToObservableCollection();
        }

        private Street _SelectedFirstPlace;
        public Street SelectedFirstPlace { get => _SelectedFirstPlace; set => Set(ref _SelectedFirstPlace, value); }

        public IRepository<Street> LastPlaceRepository = App.Services.GetService(typeof(IRepository<Street>)) as IRepository<Street>;
        public ObservableCollection<Street> LastPlacesView
        {
            get => LastPlaceRepository.Items.ToObservableCollection();
        }

        private Street _SelectedLastPlace;
        public Street SelectedLastPlace { get => _SelectedLastPlace; set => Set(ref _SelectedLastPlace, value); }

        private string _LastPlace;
        public string LastPlace { get => _LastPlace; set => Set(ref _LastPlace, value); }

        private string _FirstPlace;
        public string FirstPlace { get => _FirstPlace; set => Set(ref _FirstPlace, value); }

        public DutyDotsBaseEditViewModel(DutyDots DutyDots)
        {
            SelectedDistrict = DistrictsView.Where(u => u.id == DutyDots.idDistrict).FirstOrDefault();
            SelectedDutyDotsType = DutyDotsTypesView.Where(u => u.id == DutyDots.idDutyDotsType).FirstOrDefault();
            /*SelectedFirstPlace = FirstPlacesView.Where(u => u.id == DutyDots.idFirstPlace).FirstOrDefault();
            SelectedLastPlace = LastPlacesView.Where(u => u.id == DutyDots.idLastPlace).FirstOrDefault();*/
            FirstPlace = DutyDots.FirstPlace;
            LastPlace = DutyDots.LastPlace;
        }
        public DutyDotsBaseEditViewModel()
            : this(new DutyDots { })
        {

        }
    }
}
