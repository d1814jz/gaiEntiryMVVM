using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class AutoBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        public int AutoId;
        private string _Model;
        public string Model { get => _Model; set => Set(ref _Model, value); }
        private string _Brand;
        public string Brand { get => _Brand; set => Set(ref _Brand, value); }
        private int _Year;
        public int Year { get => _Year; set => Set(ref _Year, value); }
        private string _VinNumber;
        public string VinNumber { get => _VinNumber; set => Set(ref _VinNumber, value); }


        public AutoBaseEditViewModel(Auto auto)
        {
            Model = auto.Model;
            Brand = auto.Brand;
            Year = auto.Year;
            VinNumber = auto.VinNumber;
        }
        public AutoBaseEditViewModel()
            : this(new Auto { Brand = "1", Model = "1", Year = 1, VinNumber = "1" })
        {

        }
    }
}
