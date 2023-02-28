
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

        public static int Workerid { get; set; }
        public static int WorkeridRank { get; set; }
        public static string WorkerLastName { get; set; }
        public static string WorkerFirstName { get; set; }
        public static string WorkerSurname { get; set; }

        public static int Dutyid { get; set; }
        public static int DutyidWorker { get; set; }
        public static System.DateTime DutyDate { get; set; }
        public static string DutyPlace { get; set; }

        public static int Illegalid { get; set; }
        public static int IllegalidIllegalType { get; set; }
        public static int IllegalidDuty { get; set; }
        public static int IllegalidAuto { get; set; }
        public static int IllegalidDriver { get; set; }
        public static string IllegalPlace { get; set; }
        public static string IllegalDescription { get; set; }
 


        //другие свойства
        public static User SelectedUser { get; set; }
        public static Auto SelectedAuto { get; set; }
        public static Driver SelectedDriver { get; set; }
        public static IllegalType SelectedIllegalType { get; set; }
        public static Rank SelectedRank { get; set; }
        public static Worker SelectedWorker{ get; set; }
        public static Duty SelectedDuty { get; set; }
        public static Illegal SelectedIllegal { get; set; }
       


        public static Rank WorkerRank { get; set; }

        public static Worker RankWorker { get; set; }

        public static Worker DutyWorker { get; set; }
        public static Illegal AutoIllegal { get; set; }
        public static Illegal DriverIllegal { get; set; }
        public static Illegal IllegalTypeIllegal { get; set; }
        public static Illegal DutyIllegal { get; set; }
        public static Auto IllegalAuto { get; set; }
        public static Driver IllegalDriver { get; set; }
        public static Duty IllegalDuty { get; set; }
        public static IllegalType IllegalIllegalType { get; set; }

        public static   Worker WorkerDuty { get; set; }
        //public static Department PositionDepartment { get; set; }



        #endregion

        #region getTables
        private List<Duty> allDuties = Repositories.GetAllDuties();
        public List<Duty> AllDuties
        {
            get { return allDuties; }
            set
            {
                allDuties = value;
                NotifyPropertyChanged("AllDutys");
            }
        }

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
        private static List<Auto> allAutos = Repositories.GetAllAutos();
        //public static List<Auto> list = Repositories.GetAllAutos();
        private ObservableCollection<Auto> allAutosOc = Repositories.GetAllAutosOc();
        public  ObservableCollection<Auto> AllAutosOc
        {
            get { return allAutosOc; }
            set
            {
                allAutosOc = value;
                NoticePropertyChanged(nameof(AllAutosOc));
            }
        }
        public List<Auto> AllAutos
        {
            get { return allAutos; }
            set
            {
                allAutos = value;
                NoticePropertyChanged(nameof(AllAutos));
                //NotifyPropertyChanged("AllAutos");
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

        private List<Worker> allWorkers = Repositories.GetAllWorkers();
        public List<Worker> AllWorkers
        {
            get { return allWorkers; }
            set
            {
                allWorkers = value;
                NotifyPropertyChanged("AllWorkers");
            }
        }

        private List<Illegal> allIllegals = Repositories.GetAllIllegals();
        public List<Illegal> AllIllegals
        {
            get { return allIllegals; }
            set
            {
                allIllegals = value;
                NotifyPropertyChanged("AllIllegals");
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
                       UpdateAllAutoView();
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
                        UpdateAllDriversView();
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
                        UpdateAllIllegalTypesView();
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
                        UpdateAllRanksView();
                    }
                });
            }
        }

        private RelayCommand addNewWorker;
        public RelayCommand AddNewWorker
        {
            get
            {
                return addNewWorker?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                if (WorkerFirstName != null && WorkerLastName != null && WorkerSurname != null)
                    {
                        resultStr = Repositories.CreateWorker(WorkerLastName, WorkerFirstName, WorkerSurname, WorkerRank);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllWorkersView();
                    }
                });
            }
        }

        /*RelayCommand addNewDriver;
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
                        UpdateAllDriversView();
                    }
                });

            }
        }*/
        private RelayCommand addNewDuty;
        public RelayCommand AddNewDuty
        {
            get
            {
                return addNewDuty ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (DutyDate != null &&  DutyPlace != null)
                    {
                        resultStr = Repositories.CreateDuty(DutyDate, DutyPlace, DutyWorker);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllDutiesView();
                    }
                });
            }
        }

        private RelayCommand addNewIllegal;
        public RelayCommand AddNewIllegal
        {
            get
            {
                return addNewIllegal ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = string.Empty;
                    if (IllegalPlace != null && DutyPlace != IllegalDescription)
                    {
                        //CreateIllegal(string place, string description, IllegalType illegalType, Duty duty, Auto auto, Driver driver)
                        resultStr = Repositories.CreateIllegal(IllegalPlace, IllegalDescription, IllegalIllegalType, IllegalDuty, IllegalAuto, IllegalDriver);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllIllegalsView();
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
                        UpdateAllAutoView();
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
                        UpdateAllRanksView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editWorker;
        public RelayCommand EditWorker
        {
            get
            {
                return editWorker ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedWorker != null)
                    {
                        resultStr = Repositories.EditWorker(SelectedWorker, WorkerLastName, WorkerFirstName, WorkerSurname, WorkerRank);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();

                        wnd.Close();
                        UpdateAllWorkersView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }



        private RelayCommand editDuty;
        public RelayCommand EditDuty
        {
            get
            {
                return editDuty ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedDuty != null)
                    {
                        resultStr = Repositories.EditDuty(SelectedDuty, DutyDate, DutyPlace, DutyWorker);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllDutiesView();
                    }
                    else
                        ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand editIllegal;
        public RelayCommand EditIllegal
        {
            get
            {
                return editIllegal ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedIllegal != null)
                    {
                        resultStr = Repositories.EditIllegal(SelectedIllegal, IllegalPlace, IllegalDescription, IllegalIllegalType,
                            IllegalDuty,IllegalAuto,IllegalDriver);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                        UpdateAllIllegalsView();
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
                        UpdateAllAutoView();
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
                        UpdateAllDriversView();
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
                        UpdateAllIllegalTypesView();

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
                        UpdateAllRanksView();

                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteWorker;
        public RelayCommand DeleteWorker
        {
            get
            {
                return deleteWorker ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedWorker != null)
                    {
                        resultStr = Repositories.DeleteWorker(SelectedWorker);
                        SetNullValuesToProperties();
                        UpdateAllWorkersView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteDuty;
        public RelayCommand DeleteDuty
        {
            get
            {
                return deleteDuty ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedDuty != null)
                    {
                        resultStr = Repositories.DeleteDuty(SelectedDuty);
                        SetNullValuesToProperties();
                        UpdateAllDutiesView();
                    }
                    ShowMessageToUser(resultStr);
                });
            }
        }

        private RelayCommand deleteIllegal;
        public RelayCommand DeleteIllegal
        {
            get
            {
                return deleteIllegal ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нужно выбрать запись!";
                    if (SelectedIllegal != null)
                    {
                        resultStr = Repositories.DeleteIllegal(SelectedIllegal);
                        SetNullValuesToProperties();
                        UpdateAllIllegalsView();
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
                    //Application.Current.Shutdown();
                    MessageBox.Show(Convert.ToString(Application.Current));



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
        private void UpdateAllAutoView()
        {
            AllAutos = Repositories.GetAllAutos();
            AutoView.AllAutosView.ItemsSource = null;
            AutoView.AllAutosView.Items.Clear();
            AutoView.AllAutosView.ItemsSource = allAutos;
            AutoView.AllAutosView.Items.Refresh();
        }

        private void UpdateAllDriversView()
        {
            AllDrivers = Repositories.GetAllDrivers();
            DriverView.AllDriversView.ItemsSource = null;
            DriverView.AllDriversView.Items.Clear();
            DriverView.AllDriversView.ItemsSource = allDrivers;
            DriverView.AllDriversView.Items.Refresh();
        }

        private void UpdateAllIllegalTypesView()
        {
            AllIllegalTypes = Repositories.GetAllIllegalTypes();
            IllegalTypeView.AllIllegalTypesView.ItemsSource = null;
            IllegalTypeView.AllIllegalTypesView.Items.Clear();
            IllegalTypeView.AllIllegalTypesView.ItemsSource = AllIllegalTypes;
            IllegalTypeView.AllIllegalTypesView.Items.Refresh();
        }

        private void UpdateAllRanksView()
        {
            AllRanks = Repositories.GetAllRanks();
            RankView.AllRanksView.ItemsSource = null;
            RankView.AllRanksView.Items.Clear();
            RankView.AllRanksView.ItemsSource = allRanks;
            RankView.AllRanksView.Items.Refresh();
        }
        private void UpdateAllWorkersView()
        {
            AllWorkers = Repositories.GetAllWorkers();
            WorkerView.AllWorkersView.ItemsSource = null;
            WorkerView.AllWorkersView.Items.Clear();
            WorkerView.AllWorkersView.ItemsSource = allWorkers;
            WorkerView.AllWorkersView.Items.Refresh();
        }

        public void UpdateAllDutiesView()
        {
            AllDuties = Repositories.GetAllDuties();
            DutyView.AllDutiesView.ItemsSource = null;
            DutyView.AllDutiesView.Items.Clear();
            DutyView.AllDutiesView.ItemsSource = allDuties;
            DutyView.AllDutiesView.Items.Refresh();
        }

        public void UpdateAllIllegalsView()
        {
            AllIllegals = Repositories.GetAllIllegals();    
            IllegalView.AllIllegalsView.ItemsSource = null;
            IllegalView.AllIllegalsView.Items.Clear();
            IllegalView.AllIllegalsView.ItemsSource = allIllegals;
            IllegalView.AllIllegalsView.Items.Refresh();
        }

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

        private void OpenAddNewWorkerViewMethod()
        {
            AddNewWorkerView obj = new AddNewWorkerView();
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand openAddNewWorkerView;
        public RelayCommand OpenAddNewWorkerView
        {
            get
            {
                return openAddNewWorkerView ?? new RelayCommand(obj =>
                {
                    OpenAddNewWorkerViewMethod();
                });
            }
        }


        private void EditWorkerViewMethod(Worker Worker)
        {
            EditWorkerView obj = new EditWorkerView(Worker);
            SetCenterPositionAndOpen(obj);
        }
        private RelayCommand editWorkerView;
        public RelayCommand EditWorkerView
        {
            get
            {
                return editWorkerView ?? new RelayCommand(obj =>
                {
                    EditWorkerViewMethod(SelectedWorker);
                });
            }
        }

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

        //Дежурство
        private void OpenAddNewDutyViewMethod()
        {
            AddNewDutyView obj = new AddNewDutyView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditDutyViewMethod(Duty Duty)
        {
            EditDutyView obj = new EditDutyView(Duty);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editDutyView;
        public RelayCommand EditDutyView
        {
            get
            {
                return editDutyView ?? new RelayCommand(obj =>
                {
                    OpenEditDutyViewMethod(SelectedDuty);
                });
            }
        }

        private RelayCommand openAddNewDutyView;
        public RelayCommand OpenAddNewDutyView
        {
            get
            {
                return openAddNewDutyView ?? new RelayCommand(obj =>
                {
                    OpenAddNewDutyViewMethod();
                });
            }
        }

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
        private void OpenAddNewIllegalViewMethod()
        {
            AddNewIllegalView obj = new AddNewIllegalView();
            SetCenterPositionAndOpen(obj);
        }
        private void OpenEditIllegalViewMethod(Illegal Illegal)
        {
            EditIllegalView obj = new EditIllegalView(Illegal);
            SetCenterPositionAndOpen(obj);
        }

        private RelayCommand editIllegalView;
        public RelayCommand EditIllegalView
        {
            get
            {
                return editIllegalView ?? new RelayCommand(obj =>
                {
                    OpenEditIllegalViewMethod(SelectedIllegal);
                });
            }
        }

        private RelayCommand openAddNewIllegalView;
        public RelayCommand OpenAddNewIllegalView
        {
            get
            {
                return openAddNewIllegalView ?? new RelayCommand(obj =>
                {
                    OpenAddNewIllegalViewMethod();
                });
            }
        }

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
