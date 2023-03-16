using gaiEntiry.Base.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace gaiEntiry.Base.ViewsModel
{
    class MenuBaseViewModel
    {
        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ?? new RelayCommand(obj =>
                {
                    App.Current.Shutdown();



                });
            }
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }


        //Автомобили


        private void OpenWorkerBaseViewMethod()
        {
            WorkerBaseView obj = new WorkerBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openWorkerBaseView;

        public RelayCommand OpenWorkerBaseView
        {
            get
            {
                return openWorkerBaseView ?? new RelayCommand(obj =>
                {
                    OpenWorkerBaseViewMethod();

                });
            }
        }


        private void OpenAutoBaseViewMethod()
        {
            AutoBaseView obj = new AutoBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAutoBaseView;

        public RelayCommand OpenAutoBaseView
        {
            get
            {
                return openAutoBaseView ?? new RelayCommand(obj =>
                {
                    OpenAutoBaseViewMethod();

                });
            }
        }


        //Водители
        private void OpenDriverBaseViewMethod()
        {
            DriverBaseView obj = new DriverBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDriverBaseView;

        public RelayCommand OpenDriverBaseView
        {
            get
            {
                return openDriverBaseView ?? new RelayCommand(obj =>
                {
                    OpenDriverBaseViewMethod();

                });
            }
        }


        //Звания


        private void OpenRankBaseViewMethod()
        {
            RankBaseView obj = new RankBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openRankBaseView;

        public RelayCommand OpenRankBaseView
        {
            get
            {
                return openRankBaseView ?? new RelayCommand(obj =>
                {
                    OpenRankBaseViewMethod();

                });
            }
        }

        //Дежурство

        private void OpenDutyBaseViewMethod()
        {
            DutyBaseView obj = new DutyBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDutyBaseView;

        public RelayCommand OpenDutyBaseView
        {
            get
            {
                return openDutyBaseView ?? new RelayCommand(obj =>
                {
                    OpenDutyBaseViewMethod();

                });
            }
        }

        //Нарушения

        private void OpenIllegalBaseViewMethod()
        {
            IllegalBaseView obj = new IllegalBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIllegalBaseView;

        public RelayCommand OpenIllegalBaseView
        {
            get
            {
                return openIllegalBaseView ?? new RelayCommand(obj =>
                {
                    OpenIllegalBaseViewMethod();

                });
            }
        }

        //Учет


        private void OpenAccountingBaseViewMethod()
        {
            AccountingBaseView obj = new AccountingBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccountingBaseView;

        public RelayCommand OpenAccountingBaseView
        {
            get
            {
                return openAccountingBaseView ?? new RelayCommand(obj =>
                {
                    OpenAccountingBaseViewMethod();

                });
            }
        }

        private void OpenIllegalTypeBaseViewMethod()
        {
            IllegalTypeBaseView obj = new IllegalTypeBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIllegalTypeBaseView;

        public RelayCommand OpenIllegalTypeBaseView
        {
            get
            {
                return openIllegalTypeBaseView ?? new RelayCommand(obj =>
                {
                    OpenIllegalTypeBaseViewMethod();

                });
            }
        }
    }
}
