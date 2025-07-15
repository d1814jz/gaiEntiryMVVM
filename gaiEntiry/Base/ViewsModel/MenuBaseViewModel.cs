using gaiEntiry.Base.Report.View;
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

        private void OpenDistrictBaseViewMethod()
        {
            DistrictBaseView obj = new DistrictBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDistrictBaseView;

        public RelayCommand OpenDistrictBaseView
        {
            get
            {
                return openDistrictBaseView ?? new RelayCommand(obj =>
                {
                    OpenDistrictBaseViewMethod();

                });
            }
        }

        private void OpenPositionBaseViewMethod()
        {
            PositionBaseView obj = new PositionBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openPositionBaseView;

        public RelayCommand OpenPositionBaseView
        {
            get
            {
                return openPositionBaseView ?? new RelayCommand(obj =>
                {
                    OpenPositionBaseViewMethod();

                });
            }
        }

        private void OpenTypesOfIAPBaseViewMethod()
        {
            TypesOfIAPBaseView obj = new TypesOfIAPBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openTypesOfIAPBaseView;

        public RelayCommand OpenTypesOfIAPBaseView
        {
            get
            {
                return openTypesOfIAPBaseView ?? new RelayCommand(obj =>
                {
                    OpenTypesOfIAPBaseViewMethod();

                });
            }
        }
        private void OpenDutyDotsTypeBaseViewMethod()
        {
            DutyDotsTypeBaseView obj = new DutyDotsTypeBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDutyDotsTypeBaseView;

        public RelayCommand OpenDutyDotsTypeBaseView
        {
            get
            {
                return openDutyDotsTypeBaseView ?? new RelayCommand(obj =>
                {
                    OpenDutyDotsTypeBaseViewMethod();

                });
            }
        }

        private void OpenServiceCarBaseViewMethod()
        {
            ServiceCarBaseView obj = new ServiceCarBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openServiceCarBaseView;

        public RelayCommand OpenServiceCarBaseView
        {
            get
            {
                return openServiceCarBaseView ?? new RelayCommand(obj =>
                {
                    OpenServiceCarBaseViewMethod();

                });
            }
        }

        private void OpenAccidentBaseViewMethod()
        {
            AccidentBaseView obj = new AccidentBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccidentBaseView;

        public RelayCommand OpenAccidentBaseView
        {
            get
            {
                return openAccidentBaseView ?? new RelayCommand(obj =>
                {
                    OpenAccidentBaseViewMethod();

                });
            }
        }

        private void OpenAccidentMemberBaseViewMethod()
        {
            AccidentMemberBaseView obj = new AccidentMemberBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccidentMemberBaseView;

        public RelayCommand OpenAccidentMemberBaseView
        {
            get
            {
                return openAccidentMemberBaseView ?? new RelayCommand(obj =>
                {
                    OpenAccidentMemberBaseViewMethod();

                });
            }
        }

        private void OpenIAPBaseViewMethod()
        {
            IAPBaseView obj = new IAPBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIAPBaseView;

        public RelayCommand OpenIAPBaseView
        {
            get
            {
                return openIAPBaseView ?? new RelayCommand(obj =>
                {
                    OpenIAPBaseViewMethod();

                });
            }
        }

        private void OpenHistoryBaseViewMethod()
        {
            HistoryBaseView obj = new HistoryBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openHistoryBaseView;

        public RelayCommand OpenHistoryBaseView
        {
            get
            {
                return openHistoryBaseView ?? new RelayCommand(obj =>
                {
                    OpenHistoryBaseViewMethod();

                });
            }
        }

        private void OpenDutyDotsBaseViewMethod()
        {
            DutyDotsBaseView obj = new DutyDotsBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDutyDotsBaseView;

        public RelayCommand OpenDutyDotsBaseView
        {
            get
            {
                return openDutyDotsBaseView ?? new RelayCommand(obj =>
                {
                    OpenDutyDotsBaseViewMethod();

                });
            }
        }

        private void OpenAccountingReportBaseViewMethod()
        {
            AccountingReportView obj = new AccountingReportView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccountingReportBaseView;

        public RelayCommand OpenAccountingReportBaseView
        {
            get
            {
                return openAccountingReportBaseView ?? new RelayCommand(obj =>
                {
                    OpenAccountingReportBaseViewMethod();

                });
            }
        }

        private void OpenIllegalReportBaseViewMethod()
        {
            IllegalReportView obj = new IllegalReportView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIllegalReportBaseView;

        public RelayCommand OpenIllegalReportBaseView
        {
            get
            {
                return openIllegalReportBaseView ?? new RelayCommand(obj =>
                {
                    OpenIllegalReportBaseViewMethod();

                });
            }
        }

        private void OpenDutyReportBaseViewMethod()
        {
            DutyReportView obj = new DutyReportView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDutyReportBaseView;

        public RelayCommand OpenDutyReportBaseView
        {
            get
            {
                return openDutyReportBaseView ?? new RelayCommand(obj =>
                {
                    OpenDutyReportBaseViewMethod();

                });
            }
        }

        private void OpenAccidentReportBaseViewMethod()
        {
            AccidentReportView obj = new AccidentReportView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccidentReportBaseView;

        public RelayCommand OpenAccidentReportBaseView
        {
            get
            {
                return openAccidentReportBaseView ?? new RelayCommand(obj =>
                {
                    OpenAccidentReportBaseViewMethod();

                });
            }
        }

        private void OpenUserBaseViewMethod()
        {
            UserBaseView obj = new UserBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openUserBaseView;

        public RelayCommand OpenUserBaseView
        {
            get
            {
                return openUserBaseView ?? new RelayCommand(obj =>
                {
                    OpenUserBaseViewMethod();

                });
            }
        }

        private void OpenLogBaseViewMethod()
        {
            LogBaseView obj = new LogBaseView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openLogBaseView;

        public RelayCommand OpenLogBaseView
        {
            get
            {
                return openLogBaseView ?? new RelayCommand(obj =>
                {
                    OpenLogBaseViewMethod();

                });
            }
        }



    }
}
