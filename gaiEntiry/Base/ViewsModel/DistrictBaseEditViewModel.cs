using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DistrictBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _District; 
        public string District { get => _District; set => Set(ref _District, value); }


        public DistrictBaseEditViewModel(District district)
        {
            District = district.District1;
        }
        public DistrictBaseEditViewModel()
            : this(new District { })
        {

        }
    }
}
