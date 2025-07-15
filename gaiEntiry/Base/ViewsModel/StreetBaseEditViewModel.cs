using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace gaiEntiry.Base.ViewsModel
{
    class StreetBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public IRepository<District> DistrictRepository = App.Services.GetService(typeof(IRepository<District>)) as IRepository<District>;
        public ObservableCollection<District> DistrictCollection;
        
        public ObservableCollection<District> DistrictsView
        {
            get => DistrictRepository.Items.ToObservableCollection();
        }
        private int _idDistrict;
        public int idDistrict { get => _idDistrict; set => Set(ref _idDistrict, value); }
        private string _Street; 
        public string Street { get => _Street; set => Set(ref _Street, value); }
        private string _idDistrictData; 
        public string idDistrictData { get {
                if (string.IsNullOrEmpty(_idDistrictData))
                {
                  
                    //var entity = DistrictRepository.Get(_idDistrict);
                    var entity = DistrictRepository.Get(1);
                    _idDistrictData = entity.District1.ToString();
                    
                }
                return _idDistrictData;
                
            }
            set => Set(ref _idDistrictData, value);
        }

        private District _SelectedDistrict;

        public District SelectedDistrict { get => _SelectedDistrict; set => Set(ref _SelectedDistrict, value); }

        public StreetBaseEditViewModel(Street street)
        {
            idDistrict = street.idDistrict;
            Street = street.Street1;
            SelectedDistrict = DistrictsView.Where(u => u.id == idDistrict).FirstOrDefault();
        }

        public StreetBaseEditViewModel() : this(new Street { })
        {

        }
    }
}
