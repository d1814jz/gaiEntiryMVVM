using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base.ViewsModel
{
    class UserBaseEditViewModel : MathCore.ViewModels.ViewModel
    {
        private string _Login;
        public string Login { get => _Login; set => Set(ref _Login, value); }
        private string _Password;
        public string Password { get => _Password; set => Set(ref _Password, value); }
        private int _TypeUser;
        public int TypeUser { get => _TypeUser; set => Set(ref _TypeUser, value); }

        public UserBaseEditViewModel(User User)
        {
            Login = User.Login;
            Password = User.Password;
            TypeUser = User.Type;
        }

        public UserBaseEditViewModel() : this(new User { })
        {

        }
    }
}
