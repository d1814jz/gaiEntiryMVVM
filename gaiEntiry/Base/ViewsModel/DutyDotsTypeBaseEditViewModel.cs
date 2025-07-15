using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class DutyDotsTypeBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Type; 
        public string Type { get => _Type; set => Set(ref _Type, value); }

        public DutyDotsTypeBaseEditViewModel(DutyDotsType dutyDotsType)
        {
            Type = dutyDotsType.Type;
        }

        public DutyDotsTypeBaseEditViewModel() : this(new DutyDotsType { })
        {

        }
    }
}
