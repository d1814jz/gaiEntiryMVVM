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
        bool Edit(District district);
        bool Edit(Position position);
        bool Edit(TypesOfIAP typesOfIAP);
        bool Edit(DutyDotsType dutyDotsType);
        bool Edit(Street street);
        bool Edit(History history);
        bool Edit(ServiceCar serviceCar);
        bool Edit(IAP IAP);
        bool Edit(User user);
        bool Edit(AccidentMember accidentMember);
        bool Edit(DutyDots dutyDots);
        bool Edit(Accident accident);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
