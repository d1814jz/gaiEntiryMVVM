using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Repositories
{
    class UserRepositories
    {
        public static List<User> GetAllUsers()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.User.ToList();
                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
