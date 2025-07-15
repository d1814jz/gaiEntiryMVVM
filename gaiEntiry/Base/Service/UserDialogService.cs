using gaiEntiry.Base.View;
using gaiEntiry.Base.ViewsModel;
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
            var auto_editor_model = new AutoBaseEditViewModel(auto);

            var auto_editor_window = new AutoBaseEditView
            {
                DataContext = auto_editor_model
            };
            auto_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (auto_editor_window.ShowDialog() != true) return false;

            auto.Brand = auto_editor_model.Brand;
            auto.Model = auto_editor_model.Model;
            auto.Year = auto_editor_model.Year;
            auto.VinNumber = auto_editor_model.VinNumber;

            return true;
        }

        public bool Edit(Driver driver)
        {
            var driver_editor_model = new DriverBaseEditViewModel(driver);

            var driver_editor_window = new DriverBaseEditView
            {
                DataContext = driver_editor_model
            };

            if (driver_editor_window.ShowDialog() != true) return false;
            driver_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            driver.LastName = driver_editor_model.LastName;
            driver.FirstName = driver_editor_model.FirstName;
            driver.Surname = driver_editor_model.Surname;
            driver.Address = driver_editor_model.Address;
            driver.NumberDL = driver_editor_model.NumberDL;
            return true;
        }

        public bool Edit(IllegalType illegalType)
        {
            var illegalType_editor_model = new IllegalTypeBaseEditViewModel(illegalType);

            var illegalType_editor_window = new IllegalTypeBaseEditView
            {
                DataContext = illegalType_editor_model
            };
            illegalType_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (illegalType_editor_window.ShowDialog() != true) return false;

            illegalType.IllegalType1 = illegalType_editor_model.IllegalType1;
            illegalType.Fine = illegalType_editor_model.Fine;
            illegalType.Notice = illegalType_editor_model.Notice;
            illegalType.Tod = illegalType_editor_model.Tod;
            return true;
        }
        public bool Edit(Rank rank)
        {
            var rank_editor_model = new RankBaseEditViewModel(rank);

            var rank_editor_window = new RankBaseEditView
            {
                DataContext = rank_editor_model
            };
            rank_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (rank_editor_window.ShowDialog() != true) return false;

            rank.Rank1 = rank_editor_model.Rank;
            return true;
        }

        public bool Edit(Worker worker)
        {
            var worker_editor_model = new WorkerBaseEditViewModel(worker);

            var worker_editor_window = new WorkerBaseEditView
            {
                DataContext = worker_editor_model
            };
            worker_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (worker_editor_window.ShowDialog() != true) return false;

            worker.LastName = worker_editor_model.LastName;
            worker.FirstName = worker_editor_model.FirstName;
            worker.Surname = worker_editor_model.Surname;
            worker.Address = worker_editor_model.Address;
            worker.Birth = worker_editor_model.Birth;
            return true;
        }
        public bool Edit(Duty duty)
        {
            var duty_editor_model = new DutyBaseEditViewModel(duty);

            var duty_editor_window = new DutyBaseEditView
            {
                DataContext = duty_editor_model
            };
            duty_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (duty_editor_window.ShowDialog() != true) return false;

            duty.idWorker = duty_editor_model.SelectedWorker.id;
            duty.idServiceCar = duty_editor_model.SelectedServiceCar.id;
            duty.idDutyDots = duty_editor_model.SelectedDutyDots.id;
            duty.Date = duty_editor_model.Date;
            return true;
        }

        public bool Edit(Illegal illegal)
        {
            var illegal_editor_model = new IllegalBaseEditViewModel(illegal);

            var illegal_editor_window = new IllegalBaseEditView
            {
                DataContext = illegal_editor_model
            };
            illegal_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (illegal_editor_window.ShowDialog() != true) return false;

            /*illegal.idIllegalType = illegal_editor_model.idIllegalType;
            illegal.idAuto = illegal_editor_model.idAuto;
            illegal.idDriver = illegal_editor_model.idDriver;
            illegal.idDuty = illegal_editor_model.idDuty;*/
            illegal.idIllegalType = illegal_editor_model.SelectedIllegalType.id;
            illegal.idDriver = illegal_editor_model.SelectedDriver.id;
            illegal.idAuto = illegal_editor_model.SelectedAuto.id;
            illegal.idDuty = illegal_editor_model.SelectedDuty.id;
            illegal.Place = illegal_editor_model.Place;
            illegal.Description = illegal_editor_model.Description;
            return true;
        }

        public bool Edit(Accounting accounting)
        {
            var accounting_editor_model = new AccountingBaseEditViewModel(accounting);

            var accounting_editor_window = new AccountingBaseEditView
            {
                DataContext = accounting_editor_model
            };
            accounting_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (accounting_editor_window.ShowDialog() != true) return false;

            /*accounting.idWorker = accounting_editor_model.idWorker;
            accounting.idDriver = accounting_editor_model.idDriver;
            accounting.idAuto = accounting_editor_model.idAuto;*/
            accounting.idWorker = accounting_editor_model.SelectedWorker.id;
            accounting.idDriver = accounting_editor_model.SelectedDriver.id;
            accounting.idAuto = accounting_editor_model.SelectedAuto.id;
            accounting.Number = accounting_editor_model.Number;
            accounting.Color = accounting_editor_model.Color;
            accounting.FirstDate = accounting_editor_model.FirstDate;
            accounting.LastDate = accounting_editor_model.LastDate;

            return true;
        }

        public bool Edit(District district)
        {
            var District_editor_model = new DistrictBaseEditViewModel(district);

            var District_editor_window = new DistrictBaseEditView
            {
                DataContext = District_editor_model
            };
            District_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (District_editor_window.ShowDialog() != true) return false;
            district.District1 = District_editor_model.District;

            return true;
        }

        public bool Edit(Position position)
        {
            var Position_editor_model = new PositionBaseEditViewModel(position);

            var Position_editor_window = new PositionBaseEditView
            {
                DataContext = Position_editor_model
            };
            Position_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (Position_editor_window.ShowDialog() != true) return false;
            position.Position1 = Position_editor_model.Position;

            return true;
        }

        public bool Edit(TypesOfIAP typesOfIAP)
        {
            var TypesOfIAP_editor_model = new TypesOfIAPBaseEditViewModel(typesOfIAP);

            var TypesOfIAP_editor_window = new TypesOfIAPBaseEditView
            {
                DataContext = TypesOfIAP_editor_model
            };
            TypesOfIAP_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (TypesOfIAP_editor_window.ShowDialog() != true) return false;
            typesOfIAP.Type = TypesOfIAP_editor_model.Type;
            typesOfIAP.Encouraging = TypesOfIAP_editor_model.Encouraging;
            return true;
        }

        public bool Edit(DutyDotsType dutyDotsType)
        {
            var DutyDotsType_editor_model = new DutyDotsTypeBaseEditViewModel(dutyDotsType);

            var DutyDotsType_editor_window = new DutyDotsTypeBaseEditView
            {
                DataContext = DutyDotsType_editor_model
            };
            DutyDotsType_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (DutyDotsType_editor_window.ShowDialog() != true) return false;
            dutyDotsType.Type = DutyDotsType_editor_model.Type;
            return true;
        }

        public bool Edit(Street street)
        {
            var Street_editor_model = new StreetBaseEditViewModel(street);

            var Street_editor_window = new StreetBaseEditView
            {
                DataContext = Street_editor_model
            };
            Street_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (Street_editor_window.ShowDialog() != true) return false;
            //street.idDistrict = _DistrictRepository.Get(Street_editor_model.idDistrict);
            //street.idDistrict = Street_editor_model.idDistrict;
            street.idDistrict = (int)Street_editor_model.SelectedDistrict.id;
            street.Street1 = Street_editor_model.Street;

            return true;
        }

        public bool Edit(History history)
        {
            var History_editor_model = new HistoryBaseEditViewModel(history);

            var History_editor_window = new HistoryBaseEditView
            {
                DataContext = History_editor_model
            };
            History_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (History_editor_window.ShowDialog() != true) return false;
            //History.idDistrict = _DistrictRepository.Get(History_editor_model.idDistrict);
            //History.idDistrict = History_editor_model.idDistrict;
            history.idWorker = History_editor_model.SelectedWorker.id;
            history.idRank = History_editor_model.SelectedRank.id;
            history.idPosition = History_editor_model.SelectedPosition.id;
            history.Date = History_editor_model.DateHistory;

            return true;
        }

        public bool Edit(ServiceCar serviceCar)
        {
            var ServiceCar_editor_model = new ServiceCarBaseEditViewModel(serviceCar);

            var ServiceCar_editor_window = new ServiceCarBaseEditView
            {
                DataContext = ServiceCar_editor_model
            };
            ServiceCar_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (ServiceCar_editor_window.ShowDialog() != true) return false;

            serviceCar.Brand = ServiceCar_editor_model.Brand;
            serviceCar.Model = ServiceCar_editor_model.Model;
            serviceCar.Number = ServiceCar_editor_model.Number;
            return true;
        }

        public bool Edit(IAP IAP)
        {
            var IAP_editor_model = new IAPBaseEditViewModel(IAP);

            var IAP_editor_window = new IAPBaseEditView
            {
                DataContext = IAP_editor_model
            };
            IAP_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (IAP_editor_window.ShowDialog() != true) return false;
            IAP.idWorker = IAP_editor_model.SelectedWorker.id;
            IAP.idTypesOfIAP = IAP_editor_model.SelectedTypesOfIAP.id;
            IAP.Date = IAP_editor_model.Date;
            IAP.Description = IAP_editor_model.Description;
            return true;
        }

        public bool Edit(User user)
        {
            var User_editor_model = new UserBaseEditViewModel(user);

            var User_editor_window = new UserBaseEditView
            {
                DataContext = User_editor_model
            };
            User_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (User_editor_window.ShowDialog() != true) return false;
            user.Login = User_editor_model.Login;
            user.Password = User_editor_model.Password;
            user.Type = User_editor_model.TypeUser;
            return true;
        }

        public bool Edit(AccidentMember accidentMember)
        {
            var AccidentMember_editor_model = new AccidentMemberBaseEditViewModel(accidentMember);

            var AccidentMember_editor_window = new AccidentMemberBaseEditView
            {
                DataContext = AccidentMember_editor_model
            };
            AccidentMember_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (AccidentMember_editor_window.ShowDialog() != true) return false;
            accidentMember.Criminal = AccidentMember_editor_model.Criminal;
            accidentMember.idAccident = AccidentMember_editor_model.SelectedAccident.id;
            accidentMember.idAuto = AccidentMember_editor_model.SelectedAuto.id;
            //accidentMember.idWorker = AccidentMember_editor_model.SelectedWorker.id;
            accidentMember.idDriver = AccidentMember_editor_model.SelectedDriver.id;
            return true;
        }

        public bool Edit(DutyDots dutyDots)
        {
            var DutyDots_editor_model = new DutyDotsBaseEditViewModel(dutyDots);

            var DutyDots_editor_window = new DutyDotsBaseEditView
            {
                DataContext = DutyDots_editor_model
            };
            DutyDots_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (DutyDots_editor_window.ShowDialog() != true) return false;
            dutyDots.idDistrict = DutyDots_editor_model.SelectedDistrict.id;
            dutyDots.idDutyDotsType = DutyDots_editor_model.SelectedDutyDotsType.id;
            /*dutyDots.idFirstPlace = DutyDots_editor_model.SelectedFirstPlace.id;
            dutyDots.idLastPlace = DutyDots_editor_model.SelectedLastPlace.id;*/
            dutyDots.FirstPlace = DutyDots_editor_model.FirstPlace;
            dutyDots.LastPlace = DutyDots_editor_model.LastPlace;
            return true;
        }

        public bool Edit(Accident accident)
        {
            var Accident_editor_model = new AccidentBaseEditViewModel(accident);

            var Accident_editor_window = new AccidentBaseEditView
            {
                DataContext = Accident_editor_model
            };
            Accident_editor_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (Accident_editor_window.ShowDialog() != true) return false;
            accident.idStreet = Accident_editor_model.SelectedStreet.id;
            accident.idWorker = Accident_editor_model.SelectedWorker.id;
            accident.Place = Accident_editor_model.Place;
            accident.Description = Accident_editor_model.Description;
            accident.Date = Accident_editor_model.Date;
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
