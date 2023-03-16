using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class AccountingBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private int _idWorker;
        public int idWorker { get => _idWorker; set => Set(ref _idWorker, value); }
        private int _idDriver;
        public int idDriver { get => _idDriver; set => Set(ref _idDriver, value); }
        private int _idAuto;
        public int idAuto { get => _idAuto; set => Set(ref _idAuto, value); }
        private string _Number;
        public string Number { get => _Number; set => Set(ref _Number, value); }
        private string _Color;
        public string Color { get => _Color; set => Set(ref _Color, value); }
        private DateTime _FirstDate;
        public DateTime FirstDate { get => _FirstDate; set => Set(ref _FirstDate, value); }
        private DateTime _LastDate;
        public DateTime LastDate { get => _LastDate; set => Set(ref _LastDate, value); }

        public AccountingBaseEditViewModel(Accounting accounting)
        {
            idWorker = accounting.idWorker;
            idDriver = accounting.idDriver;
            idAuto = accounting.idAuto;
            Number = accounting.Number;
            Color = accounting.Color;
            FirstDate = accounting.FirstDate;
            LastDate = accounting.LastDate;

        }
        public AccountingBaseEditViewModel()
            :this(new Accounting { })
        {

        }
    }
}
