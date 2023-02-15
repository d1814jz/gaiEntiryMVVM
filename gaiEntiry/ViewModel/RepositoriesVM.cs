
using gaiEntiry.Add;
using gaiEntiry.Edit;
using gaiEntiry.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace gaiEntiry.ViewModel
{
    class RepositoriesVM : INotifyPropertyChanged
    {
        #region property

        //+пользователь свойства
        int Userid { get; set; }
        private string _userLogin;
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                NotifyPropertyChanged(nameof(UserLogin));
            }
        }
        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                NotifyPropertyChanged(nameof(UserPassword));
            }
        }
        string UserType { get; set; }

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

        public static int Autoid { get; set; }
        public static string AutoBrand { get; set; }
        public static string AutoModel { get; set; }
        public static int AutoYear { get; set; }
        public static string AutoVinNumber { get; set; }
        public static int Driverid { get; set; }
        public static string DriverLastName { get; set; }
        public static string DriverFirstName { get; set; }
        public static string DriverSurname { get; set; }
        public static string DriverAddress { get; set; }
        public static string DriverNumberDL { get; set; }

        public static int IllegalTypeid { get; set; }
        public static string IllegalTypeIllegalType1 { get; set; }
        public static int IllegalTypeFine { get; set; }
        public static bool IllegalTypeNotice { get; set; }
        public static int IllegalTypeTod { get; set; }

        public static int Rankid { get; set; }
        public static string RankRank1 { get; set; }
        //другие свойства
        public static User SelectedUser { get; set; }
        public static Auto SelectedAuto { get; set; }
        public static Driver SelectedDriver { get; set; }
        public static IllegalType SelectedIllegalType { get; set; }
        public static Rank SelectedRank { get; set; }



        #endregion


        #region getTables
        private List<User> allUsers = Repositories.GetAllUsers();
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
        //все автомобили
        private List<Auto> allAutos = Repositories.GetAllAutos();
        public List<Auto> AllAutos
        {
            get { return allAutos; }
            set
            {
                allAutos = value;
                NotifyPropertyChanged("AllAutos");
            }
        }
        //все водители

        private List<Driver> allDrivers = Repositories.GetAllDrivers();
        public List<Driver> AllDrivers
        {
            get { return allDrivers; }
            set
            {
                allDrivers = value;
                NotifyPropertyChanged("AllDrivers");
            }
        }

        //все виды нарущение

        private List<IllegalType> allIllegalTypes = Repositories.GetAllIllegalTypes();
        public List<IllegalType> AllIllegalTypes
        {
            get { return allIllegalTypes; }
            set
            {
                allIllegalTypes = value;
                NotifyPropertyChanged("AllIllegalTypes");
            }
        }
        //все звания
        private List<Rank> allRanks = Repositories.GetAllRanks();
        public List<Rank> AllRanks
        {
            get { return allRanks; }
            set
            {
                allRanks = value;
                NotifyPropertyChanged("AllRanks");
            }
        }

        #endregion

       

        #region addRecord


        private RelayCommand addNewAuto;
        public RelayCommand AddNewAuto
        {
           
            get
            {
                return addNewAuto ?? new RelayCommand(obj =>
               {
                   Window wnd = obj as Window;
                   string resultStr = string.Empty;
                   if (AutoBrand != null && AutoModel != null & AutoYear != 0 && AutoVinNumber != null)
                   {
                       resultStr = Repositories.CreateAuto(AutoBrand, AutoModel, AutoYear, AutoVinNumber);
                       ShowMessageToUser(resultStr);
                       SetNullValuesToProperties();
                       wnd.Close();
                   }
               });
            }

        }

        RelayCommand addNewDriver; 
        public RelayCommand AddNewDriver
        {
            get
            {
                return addNewDriver ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (DriverFirstName != null && DriverLastName != null && DriverSurname != null &&
                        DriverAddress != null && DriverNumberDL != null)
                    {
                        resultStr = Repositories.CreateDriver(DriverLastName, DriverFirstName, DriverSurname, DriverAddress, DriverNumberDL);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();

                    }
                });
                
            }
        }

        private RelayCommand addNewIllegalType;
        public RelayCommand AddNewIllegalType
        {

            get
            {
                return addNewIllegalType ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if(IllegalTypeIllegalType1 != null)
                    {
                        resultStr = Repositories.CreateIllegalType(IllegalTypeIllegalType1, IllegalTypeFine, IllegalTypeNotice, IllegalTypeTod);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }

        private RelayCommand addNewRank; 
        public RelayCommand AddNewRank
        {
            get
            {
                return addNewRank ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty; 
                    if(RankRank1 != null)
                    {
                        resultStr = Repositories.CreateRank(RankRank1);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }

        #endregion

        #region editRecord

     

        private RelayCommand editAuto;
        public RelayCommand EditAuto
        {
            get
            {
                return editAuto ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Автомобиль не выбран";
                    if(SelectedAuto != null)
                    {
                        resultStr = Repositories.EditAuto(SelectedAuto, AutoBrand, AutoModel, AutoYear, AutoVinNumber);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editRank;
        public RelayCommand EditRank
        {
            get
            {
                return editRank ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Звание не выбрано";
                    if (SelectedRank != null)
                    {
                        resultStr = Repositories.EditRank(SelectedRank, RankRank1);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        #endregion

        #region deleteRecord

        private RelayCommand deleteAuto;
        public RelayCommand DeleteAuto
        {
            get
            {
                return deleteAuto ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if(SelectedAuto != null)
                    {
                        resultStr = Repositories.DeleteAuto(SelectedAuto);
                        SetNullValuesToProperties();
                        
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteDriver;
        public RelayCommand DeleteDriver
        {
            get
            {
                return deleteDriver ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedDriver != null)
                    {
                        resultStr = Repositories.DeleteDriver(SelectedDriver);
                        SetNullValuesToProperties();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteIllegalType;
        public RelayCommand DeleteIllegalType
        {
            get
            {
                return deleteIllegalType ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedIllegalType != null)
                    {
                        resultStr = Repositories.DeleteIllegalType(SelectedIllegalType);
                        SetNullValuesToProperties();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteRank;
        public RelayCommand DeleteRank
        {
            get
            {
                return deleteRank ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedRank != null)
                    {
                        resultStr = Repositories.DeleteRank(SelectedRank);
                        SetNullValuesToProperties();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }
        #endregion


        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    User user = allUsers.Find(u => u.Login == UserLogin && u.Password == UserPassword);
                    if (user is null)
                    {
                        ShowMessageToUser("Ошибка");
                    }
                    else
                    {
                        MenuView menuView = new MenuView();
                        SetCenterPositionAndOpen(menuView);
                        SetNullValuesToProperties();
                        
                        
                    }

                });
            }
        }

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

        #region Окна
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #region updateViews
     
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


        #endregion

        #region Windows

        //Автомобили
        private void OpenAddNewAutoViewMethod()
        {
            AddNewAutoView obj = new AddNewAutoView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewAutoView;
        public RelayCommand OpenAddNewAutoView
        {
            get
            {
                return openAddNewAutoView ?? new RelayCommand(obj =>
                {
                    OpenAddNewAutoViewMethod();
                });
            }
        }

        private void EditAutoViewMethod(Auto auto)
        {
            EditAutoView obj = new EditAutoView(auto);
            SetCenterPositionAndOpen(obj);
        }
        private RelayCommand editAutoView;
        public RelayCommand EditAutoView
        {
            get
            {
                return editAutoView ?? new RelayCommand(obj =>
                {
                    EditAutoViewMethod(SelectedAuto);
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
        private void OpenAddNewDriverViewMethod()
        {
            AddNewDriverView obj = new AddNewDriverView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewDriverView;
        public RelayCommand OpenAddNewDriverView
        {
            get
            {
                return openAddNewDriverView ?? new RelayCommand(obj =>
                {
                    OpenAddNewDriverViewMethod();
                });
            }
        }
        private void OpenEditDriverViewMethod(Driver driver)
        {
            EditDriverView obj = new EditDriverView(driver);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editDriverView;
        public RelayCommand EditDriverView
        {
            get
            {
                return editDriverView ?? new RelayCommand(obj =>
                {
                    OpenEditDriverViewMethod(SelectedDriver);
                });
            }
        }
        private RelayCommand editDriver;
        public RelayCommand EditDriver
        {
            get
            {
                return editDriver ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Автомобиль не выбран";
                    if (SelectedDriver != null)
                    {
                        resultStr = Repositories.EditDriver(SelectedDriver, DriverLastName, DriverFirstName, DriverSurname, DriverAddress, DriverNumberDL);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        //Звания


        private void OpenAddNewRankViewMethod()
        {
            AddNewRankView obj = new AddNewRankView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditRankViewMethod(Rank rank)
        {
            EditRankView obj = new EditRankView(rank);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editRankView;
        public RelayCommand EditRankView
        {
            get
            {
                return editRankView ?? new RelayCommand(obj =>
                {
                    OpenEditRankViewMethod(SelectedRank);
                });
            }
        }

        private RelayCommand openAddNewRankView;
        public RelayCommand OpenAddNewRankView
        {
            get
            {
                return openAddNewRankView ?? new RelayCommand(obj =>
                {
                    OpenAddNewRankViewMethod();
                });
            }
        }

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


        //IllegalType 

        #region illegalType
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
        private void OpenAddNewIllegalTypeViewMethod()
        {
            AddNewIllegalTypeView obj = new AddNewIllegalTypeView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewIllegalTypeView;
        public RelayCommand OpenAddNewIllegalTypeView
        {
            get
            {
                return openAddNewIllegalTypeView ?? new RelayCommand(obj =>
                {
                    OpenAddNewIllegalTypeViewMethod();
                });
            }
        }

        private void OpenEditIllegalTypeViewMethod(IllegalType illegalType)
        {
            EditIllegalTypeView obj = new EditIllegalTypeView(illegalType);
            SetCenterPositionAndOpen(obj);
        }
        private RelayCommand editIllegalType;
        public RelayCommand EditIllegalType {
            get
            {
                return editIllegalType ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Вид нарушения не выбран";
                    if (SelectedIllegalType != null)
                    {
                        resultStr = Repositories.EditIllegalType(SelectedIllegalType, IllegalTypeIllegalType1, IllegalTypeFine, IllegalTypeNotice,IllegalTypeTod);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();

                        wnd.Close();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editIllegalTypeView;
        public RelayCommand EditIllegalTypeView
        {
            get
            {
                return editIllegalTypeView ?? new RelayCommand(obj =>
                {
                    OpenEditIllegalTypeViewMethod(SelectedIllegalType);
                });
            }
        }
        #endregion
        
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
        #endregion
    }
}
