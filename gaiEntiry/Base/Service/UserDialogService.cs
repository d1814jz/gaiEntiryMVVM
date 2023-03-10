using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry.Base.Service
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Auto auto)
        {
            return true;
        }

        public bool ConfirmInformation(string Information, string Caption) => MessageBox
           .Show(
                Information, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Information)
                == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;

        public bool ConfirmError(string Error, string Caption) => MessageBox
           .Show(
                Error, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Error)
                == MessageBoxResult.Yes;
    }
}
