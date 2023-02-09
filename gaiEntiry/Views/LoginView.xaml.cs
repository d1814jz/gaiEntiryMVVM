using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gaiEntiry.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public string Login;
        public string Password;
        /*
        private string _login;
        private string _password;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        */

        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login = textBoxLogin.Text;
            Password = textBoxPassword.Password;
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var users = db.User.ToList();
                foreach(User u in users)
                {
                    if(u.Login == Login & u.Password == Password)
                    {
                        MenuView menuView = new MenuView(u.Login, u.Type);
                        this.Hide();
                        menuView.Show();
                        return;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
