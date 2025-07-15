using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class PositionBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Position;
        public string Position { get => _Position; set => Set(ref _Position, value); }
        
        public PositionBaseEditViewModel(Position position)
        {
            Position = position.Position1;
        }
        public PositionBaseEditViewModel()
            : this(new Position { })
        {

        }
    }

}
