using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Base
{
    internal interface IUserDialog
    {
        bool Edit(Auto auto);
        bool Edit(Driver driver);
        bool Edit(IllegalType illegalType);
        bool Edit(Rank rank);
        bool Edit(Worker worker);
        bool Edit(Duty duty);
        bool Edit(Illegal illegal);
        bool Edit(Accounting accounting);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
