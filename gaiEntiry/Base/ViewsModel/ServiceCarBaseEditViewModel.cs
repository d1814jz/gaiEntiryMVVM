using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class ServiceCarBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Model;
        public string Model { get => _Model; set => Set(ref _Model, value); }
        private string _Brand;
        public string Brand { get => _Brand; set => Set(ref _Brand, value); }
        private string _Number;
        public string Number { get => _Number; set => Set(ref _Number, value); }


        public ServiceCarBaseEditViewModel(ServiceCar ServiceCar)
        {
            Model = ServiceCar.Model;
            Brand = ServiceCar.Brand;
            Number = ServiceCar.Number;
        }
        public ServiceCarBaseEditViewModel()
            : this(new ServiceCar {})
        {

        }
    }
}
