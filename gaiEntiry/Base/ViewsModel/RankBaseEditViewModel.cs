using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class RankBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Rank;
        public string Rank { get => _Rank; set => Set(ref _Rank, value); }

        public RankBaseEditViewModel(Rank rank)
        {
            Rank = rank.Rank1;
        }

        public RankBaseEditViewModel() : this(new Rank { })
        {
            
        }
    }
}
