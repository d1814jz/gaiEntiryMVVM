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

            if (worker_editor_window.ShowDialog() != true) return false;

            worker.LastName = worker_editor_model.LastName;
            worker.FirsName = worker_editor_model.FirstName;
            worker.Surname = worker_editor_model.Surname;
            worker.idRank = worker_editor_model.idRank;
            return true;
        }
        public bool Edit(Duty duty)
        {
            var duty_editor_model = new DutyBaseEditViewModel(duty);

            var duty_editor_window = new DutyBaseEditView
            {
                DataContext = duty_editor_model
            };

            if (duty_editor_window.ShowDialog() != true) return false;

            duty.idWorker = duty_editor_model.idWorker;
            duty.Date = duty_editor_model.Date;
            duty.Place = duty_editor_model.Place;
            return true;
        }

        public bool Edit(Illegal illegal)
        {
            var illegal_editor_model = new IllegalBaseEditViewModel(illegal);

            var illegal_editor_window = new IllegalBaseEditView
            {
                DataContext = illegal_editor_model
            };

            if (illegal_editor_window.ShowDialog() != true) return false;

            illegal.idIllegalType = illegal_editor_model.idIllegalType;
            illegal.idAuto = illegal_editor_model.idAuto;
            illegal.idDriver = illegal_editor_model.idDriver;
            illegal.idDuty = illegal_editor_model.idDuty;
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

            if (accounting_editor_window.ShowDialog() != true) return false;

            accounting.idWorker = accounting_editor_model.idWorker;
            accounting.idDriver = accounting_editor_model.idDriver;
            accounting.idAuto = accounting_editor_model.idAuto;
            accounting.Number = accounting_editor_model.Number;
            accounting.Color = accounting_editor_model.Color;
            accounting.FirstDate = accounting_editor_model.FirstDate;
            accounting.LastDate = accounting_editor_model.LastDate;

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
