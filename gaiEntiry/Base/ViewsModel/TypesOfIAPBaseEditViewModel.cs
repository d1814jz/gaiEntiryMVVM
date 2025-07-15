using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class TypesOfIAPBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Type;
        public string Type { get => _Type; set => Set(ref _Type, value); }
        private string _Encouraging; 
        public string Encouraging { get => _Encouraging; set => Set(ref _Encouraging, value); }

        public TypesOfIAPBaseEditViewModel(TypesOfIAP typesOfIAP)
        {
            Type = typesOfIAP.Type;
            Encouraging = typesOfIAP.Encouraging;
        }

        public TypesOfIAPBaseEditViewModel() : this(new TypesOfIAP { })
        {

        }
    }
}
