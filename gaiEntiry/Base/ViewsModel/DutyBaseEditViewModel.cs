using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private int _idWorker;
        public int idWorker { get => _idWorker; set => Set(ref _idWorker, value); }
        private DateTime _Date;
        public DateTime Date { get => _Date; set => Set(ref _Date, value); }
        private string _Place;
        public string Place { get => _Place; set => Set(ref _Place, value); }

        public DutyBaseEditViewModel(Duty duty)
        {
            idWorker = duty.idWorker;
            Date = duty.Date;
            Place = duty.Place;
        }

        public DutyBaseEditViewModel()
            : this(new Duty { })
        {

        }
    }
}
