using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class IllegalBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private int _idIllegalType;
        public int idIllegalType { get => _idIllegalType; set => Set(ref _idIllegalType, value); }
        private int _idDuty;
        public int idDuty { get => _idDuty; set => Set(ref _idDuty, value); }
        private int _idAuto;
        public int idAuto { get => _idAuto; set => Set(ref _idAuto, value); }
        private int _idDriver;
        public int idDriver { get => _idDriver; set => Set(ref _idDriver, value); }
        private string _Place;
        public string Place { get => _Place; set => Set(ref _Place, value); }
        private string _Description;
        public string Description { get => _Description; set => Set(ref _Description, value); }


        public IllegalBaseEditViewModel() 
            :this(new Illegal { })
        {
        }

        public IllegalBaseEditViewModel(Illegal illegal)
        {
            idIllegalType = illegal.idIllegalType;
            idDuty = illegal.idDuty;
            idAuto = illegal.idAuto;
            idDriver = illegal.idDriver;
            Place = illegal.Place;
            Description = illegal.Description;

        }


    }
}
