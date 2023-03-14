
using gaiEntiry.Add;
using gaiEntiry.Edit;
using gaiEntiry.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace gaiEntiry.ViewsModel
{
    class RepositoriesVM : INotifyPropertyChanged
    {

        #region property



        //+Автомобиль свойства
        /*public int Autoid { get; set; }
        private string _autoBrand;
        public string AutoBrand
        {
            get
            {
                return _autoBrand;
            }
            set
            {
                _autoBrand = value;
                NotifyPropertyChanged(nameof(AutoBrand));
            }
        }
        private string _autoModel;
        public string AutoModel
        {
            get
            {
                return _autoModel;
            }
            set
            {
                _autoModel = value;
                NotifyPropertyChanged(nameof(AutoModel));
            }
        }
        private int _autoYear;
        public int AutoYear
        {
            get
            {
                return _autoYear;
            }
            set
            {
                _autoYear = value;
                NotifyPropertyChanged(nameof(AutoYear));
            }
        }

        private string _autoVinNumber;
        public string AutoVinNumber
        {
            get
            {
                return _autoVinNumber;
            }
            set
            {
                _autoVinNumber = value;
                NotifyPropertyChanged(nameof(AutoVinNumber));
            }
        }

        //+Водитель свойства

        public int Driverid { get; set; }
        private string _driverLastName; 
        public string DriverLastName
        {
            get
            {
                return _driverLastName;
            }
            set
            {
                _driverLastName = value;
                NotifyPropertyChanged(nameof(DriverLastName));
            }
        }
        public string _driverFirstName;
        public string DriverFirstName
        {
            get
            {
                return _driverFirstName;
            }
            set
            {
                _driverFirstName = value;
                NotifyPropertyChanged(nameof(DriverFirstName));
            }
        }
        private string _driverSurname;
        public string DriverSurname
        {
            get
            {
                return _driverSurname;
            }
            set
            {
                _driverSurname = value;
                NotifyPropertyChanged(nameof(DriverSurname));
            }
        }
        
        private string _driverAddress; 
        public string DriverAddress
        {
            get
            {
                return _driverAddress;
            }
            set
            {
                _driverAddress = value;
                NotifyPropertyChanged(nameof(DriverAddress));
            }
        }
        private string _driverNumberDL;
        public string DriverNumberDL
        {
            get
            {
                return _driverNumberDL;
            }
            set
            {
                _driverNumberDL = value;
                NotifyPropertyChanged(nameof(DriverNumberDL));
            }
        }

        //+Виды нарушений свойства
        public int IllegalTypeid { get; set; }
        private string _illegalTypeIllegalType1;
        public string IllegalTypeIllegalType1
        {
            get
            {
                return _illegalTypeIllegalType1;
            }
            set
            {
                _illegalTypeIllegalType1 = value;
                NotifyPropertyChanged(nameof(IllegalTypeIllegalType1));
            }
        }
               

        private int _illegalTypeFine;
        public int IllegalTypeFine
        {
            get
            {
                return _illegalTypeFine;
            }
            set
            {
                _illegalTypeFine = value;
                NotifyPropertyChanged(nameof(IllegalTypeFine));
            }
        }

        private bool _illegalTypeNotice;
        public bool IllegalTypeNotice
        {
            get
            {
                return _illegalTypeNotice;
            }
            set
            {
                _illegalTypeNotice = value;
                NotifyPropertyChanged(nameof(IllegalTypeNotice));
            }
        }

        private int _illegalTypeTod;
        public int IllegalTypeTod
        {
            get
            {
                return _illegalTypeTod;
            }
            set
            {
                _illegalTypeTod = value;
                NotifyPropertyChanged(nameof(IllegalTypeTod));
            }
        }

        //+Звания cвойства

        public int Rankid { get; set; }
        private string _rankRank1; 
        public string RankRank1
        {
            get
            {
                return _rankRank1;
            }
            set
            {
                _rankRank1 = value;
                NotifyPropertyChanged(nameof(RankRank1));
            }
        }
        */

        #endregion



        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ?? new RelayCommand(obj =>
                {
                    Application.Current.Shutdown();



                });
            }
        }


        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        /*#region updateViews

        private void SetNullValuesToProperties()
        {
            //для автомобиля
            AutoBrand = null;
            AutoModel = null;
            //AutoYear = 0;
            AutoVinNumber = null;
            //для водителя

            DriverFirstName = null;
            DriverLastName = null;
            DriverSurname = null;
            DriverAddress = null;
            DriverNumberDL = null;
            //для вида нарушения
            IllegalTypeIllegalType1 = null;
            IllegalTypeFine = 0;
            IllegalTypeNotice = false;
            //IllegalTypeTod = 0;

            //для звания
            RankRank1 = null;
            //для дежурства
            //для сотрудника
            //для нарушения
            //для учета 

          

        }


        #endregion*/

        #region Windows

        //Автомобили


        private void OpenWorkerViewMethod()
        {
            WorkerView obj = new WorkerView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openWorkerView;

        public RelayCommand OpenWorkerView
        {
            get
            {
                return openWorkerView ?? new RelayCommand(obj =>
                {
                    OpenWorkerViewMethod();

                });
            }
        }


        private void OpenAutoViewMethod()
        {
            AutoView obj = new AutoView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAutoView;

        public RelayCommand OpenAutoView
        {
            get
            {
                return openAutoView ?? new RelayCommand(obj =>
                {
                    OpenAutoViewMethod();

                });
            }
        }


        //Водители
        private void OpenDriverViewMethod()
        {
            DriverView obj = new DriverView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDriverView;

        public RelayCommand OpenDriverView
        {
            get
            {
                return openDriverView ?? new RelayCommand(obj =>
                {
                    OpenDriverViewMethod();

                });
            }
        }


        //Звания


        private void OpenRankViewMethod()
        {
            RankView obj = new RankView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openRankView;

        public RelayCommand OpenRankView
        {
            get
            {
                return openRankView ?? new RelayCommand(obj =>
                {
                    OpenRankViewMethod();

                });
            }
        }

        //Дежурство

        private void OpenDutyViewMethod()
        {
            DutyView obj = new DutyView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openDutyView;

        public RelayCommand OpenDutyView
        {
            get
            {
                return openDutyView ?? new RelayCommand(obj =>
                {
                    OpenDutyViewMethod();

                });
            }
        }

        //Нарушения

        private void OpenIllegalViewMethod()
        {
            IllegalView obj = new IllegalView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIllegalView;

        public RelayCommand OpenIllegalView
        {
            get
            {
                return openIllegalView ?? new RelayCommand(obj =>
                {
                    OpenIllegalViewMethod();

                });
            }
        }

        //Учет


        private void OpenAccountingViewMethod()
        {
            AccountingView obj = new AccountingView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAccountingView;

        public RelayCommand OpenAccountingView
        {
            get
            {
                return openAccountingView ?? new RelayCommand(obj =>
                {
                    OpenAccountingViewMethod();

                });
            }
        }

        private void OpenIllegalTypeViewMethod()
        {
            IllegalTypeView obj = new IllegalTypeView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openIllegalTypeView;

        public RelayCommand OpenIllegalTypeView
        {
            get
            {
                return openIllegalTypeView ?? new RelayCommand(obj =>
                {
                    OpenIllegalTypeViewMethod();

                });
            }
        }
        #endregion

        #region Inotify

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void NoticePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}