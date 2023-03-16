using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DriverBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _LastName;
        public string LastName { get => _LastName; set => Set(ref _LastName, value); }
        private string _FirstName;
        public string FirstName { get => _FirstName; set => Set(ref _FirstName, value); }
        private string _Surname;
        public string Surname { get => _Surname; set => Set(ref _Surname, value); }
        private string _Address;
        public string Address { get => _Address; set => Set(ref _Address, value); }
        private string _NumberDL;
        public string NumberDL { get => _NumberDL; set => Set(ref _NumberDL, value); }

        public DriverBaseEditViewModel(Driver driver)
        {
            LastName = driver.LastName;
            FirstName = driver.FirstName;
            Surname = driver.Surname;
            Address = driver.Address;
            NumberDL = driver.NumberDL;
        }

        public DriverBaseEditViewModel() 
            : this(new Driver { LastName = "1", FirstName = "1", Surname = "1",Address = "1", NumberDL = "1" })
        {

        }
    }
}
