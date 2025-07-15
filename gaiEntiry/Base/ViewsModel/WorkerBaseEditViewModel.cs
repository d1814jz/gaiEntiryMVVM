using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class WorkerBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private int _idRank; 
        public int idRank { get => _idRank; set => Set(ref _idRank, value); }
        private string _LastName;
        public string LastName { get => _LastName; set => Set(ref _LastName, value); }
        private string _FirstName;
        public string FirstName { get => _FirstName; set => Set(ref _FirstName, value); }
        private string _Surname;
        public string Surname { get => _Surname; set => Set(ref _Surname, value); }
        private string _Address;
        public string Address { get => _Address; set => Set(ref _Address, value); }
        private DateTime _Birth;
        public DateTime Birth { get => _Birth; set => Set(ref _Birth, value); }

        public WorkerBaseEditViewModel(Worker worker)
        {
            LastName = worker.LastName;
            FirstName = worker.FirstName;
            Surname = worker.Surname;
            Address = worker.Address;
            Birth = worker.Birth;
        }

        public WorkerBaseEditViewModel()
            : this(new Worker{})
        {

        }
    }
}
