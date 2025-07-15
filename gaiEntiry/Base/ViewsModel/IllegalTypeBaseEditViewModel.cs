using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class IllegalTypeBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _IllegalType1;
        public string IllegalType1 { get => _IllegalType1; set => Set(ref _IllegalType1, value); }
        private int _Fine;
        public int Fine { get => _Fine; set => Set(ref _Fine, value); }
        private string _Notice;
        public string Notice { get => _Notice; set => Set(ref _Notice, value); }
        private int _Tod;
        public int Tod { get => _Tod; set => Set(ref _Tod, value); }


        public IllegalTypeBaseEditViewModel(IllegalType illegalType)
        {
            IllegalType1 = (string)illegalType.IllegalType1;
            Fine = (int)illegalType.Fine;
            Notice = illegalType.Notice;
            Tod = illegalType.Tod;
        }

        public IllegalTypeBaseEditViewModel() : this(new IllegalType { })
        {

        }
    }
}
