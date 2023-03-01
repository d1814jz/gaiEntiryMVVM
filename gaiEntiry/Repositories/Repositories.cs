using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry
{
    class Repositories
    {
        //+получить пользователей
        public static List<User> GetAllUsers()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.User.ToList();
                return result;
            }
        }
        //+получить автомобили
        public static List<Auto> GetAllAutos()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Auto.ToList();
                return result;
            }
        }

        public static ObservableCollection<Auto> GetAllAutosOc()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                ObservableCollection<Auto> result = new ObservableCollection<Auto>(db.Auto.ToList());
                return result;
            }
        }
        //+создать автомобиль 

        public static string CreateAuto(string Brand, string Model, int Year, string VinNumber)
        {
            string result = "Такой автомобиль уже есть";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Auto.Any(u => u.VinNumber == VinNumber);
                if (!checkIsExist)
                {
                    Auto newAuto = new Auto
                    {
                        Model = Model,
                        Brand = Brand,
                        Year = Year,
                        VinNumber = VinNumber

                    };
                    db.Auto.Add(newAuto);
                    db.SaveChanges();
                    result = "Автомобиль добавлен";
                }
                return result;
            }
        }

        //+изменить автомобиль 

        public static string EditAuto(Auto oldAuto, string newBrand, string newModel, int newYear, string newVinNumber)
        {
            string result = "Такого автомобиля не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Auto auto = db.Auto.FirstOrDefault(u => u.id == oldAuto.id);
                auto.Model = newModel;
                auto.Brand = newBrand;
                auto.Year = newYear;
                auto.VinNumber = newVinNumber;
                db.SaveChanges();
                result = "Автомобиль " + auto.VinNumber + "изменен";
            }
            return result;
        }



        //+удалить автомобиль


        public static string DeleteAuto(Auto auto)
        {
            string result = "Такого автомобиля не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {

                var tmp = db.Auto.Where(u => u.id == auto.id).FirstOrDefault();
                db.Auto.Remove(tmp);
                db.SaveChanges();
                result = "Автомобиль удален!" + auto.VinNumber;
            }
            return result;
        }

        //получить автомобиль по id
        public static Auto GetAutoById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Auto auto = db.Auto.FirstOrDefault(u => u.id == id);
                return auto;
            }
        }

        //+получить виды нарушений
        public static List<IllegalType> GetAllIllegalTypes()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.IllegalType.ToList();
                return result;
            }
        }
        //+создать вид нарушения

        public static string CreateIllegalType(string IllegalType, int Fine, bool Notice, int Tod)
        {
            string result = "Такой вид нарушения уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.IllegalType.Any(u => u.IllegalType1 == IllegalType
                    && u.Fine == Fine && u.Tod == Tod && u.Notice == Notice);
                if (!checkIsExist)
                {
                    IllegalType newIllegalType = new IllegalType
                    {
                        IllegalType1 = IllegalType,
                        Fine = Fine,
                        Notice = Notice,
                        Tod = Tod
                    };
                    db.IllegalType.Add(newIllegalType);
                    db.SaveChanges();
                    result = "Вид нарушения добавлен";
                }
                return result;
            }
        }
        //+изменить вид нарушения
        public static string EditIllegalType(IllegalType oldIllegalType, string newIllegalType, int newFine, bool newNotice, int newTod)
        {
            string result = "Такого вида нарушения не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                IllegalType illegalType = db.IllegalType.FirstOrDefault(u => u.id == oldIllegalType.id);
                illegalType.IllegalType1 = newIllegalType;
                illegalType.Fine = newFine;
                illegalType.Notice = newNotice;
                illegalType.Tod = newTod;
                db.SaveChanges();
                result = "Вид нарушения " + illegalType.IllegalType1 + " изменен";
            }
            return result;

        }


        //+удалить вид нарушения
        public static string DeleteIllegalType(IllegalType illegalType)
        {
            string result = "Такого вида нарушения не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.IllegalType.Where(u => u.id == illegalType.id).FirstOrDefault(); ;
                db.IllegalType.Remove(tmp);
                db.SaveChanges();
                result = "Вид нарушения " + illegalType.IllegalType1 + " удален";
            }
            return result;
        }


        //Получить вид нарушения по id
        public static IllegalType GetIllegalTypeById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                IllegalType it = db.IllegalType.FirstOrDefault(u => u.id == id);
                return it;
            }
        }

        //+получить водителей
        public static List<Driver> GetAllDrivers()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Driver.ToList();
                return result;
            }
        }
        //+создать водителя

        public static string CreateDriver(string LastName, string FirstName, string Surname, string Address, string NumberDL)
        {
            string result = "Такой водитель уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var checkIsExist = db.Driver.Any(u => u.FirstName == FirstName && u.LastName == LastName
                    && u.Surname == Surname && u.Address == Address && u.NumberDL == NumberDL);
                if (!checkIsExist)
                {
                    Driver newDriver = new Driver
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Surname = Surname,
                        Address = Address,
                        NumberDL = NumberDL

                    };

                    db.Driver.Add(newDriver);
                    db.SaveChanges();
                    result = "Водитель добавлен";
                }
                return result;
            }
        }


        //+изменить водителя
        public static string EditDriver(Driver oldDriver, string newFirstName, string newLastName, string newSurname,
            string newAddress, string newNumberDL)
        {
            string result = "Такого водителя не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Driver driver = db.Driver.FirstOrDefault(u => u.id == oldDriver.id);
                driver.FirstName = newFirstName;
                driver.LastName = newLastName;
                driver.Surname = newSurname;
                driver.Address = newAddress;
                driver.NumberDL = newNumberDL;
                db.SaveChanges();
                result = "Водитель изменен";
            }
            return result;
        }



        //+удалить водителя
        public static string DeleteDriver(Driver driver)
        {
            string result = "Такого водителя не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Driver.Where(u => u.id == driver.id).FirstOrDefault();
                db.Driver.Remove(tmp);
                db.SaveChanges();
                result = "Водитель удален";
            }
            return result;
        }

        //получить водителя по id

        public static Driver GetDriverById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Driver driver = db.Driver.FirstOrDefault(u => u.id == id);
                return driver;
            }
        }

        //+получить звания
        public static List<Rank> GetAllRanks()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Rank.ToList();
                return result;
            }
        }
        //+добавить звание

        public static string CreateRank(string Rank)
        {
            string result = "Такое звание уже есть";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var checkIsExist = db.Rank.Any(u => u.Rank1 == Rank);
                if (!checkIsExist)
                {
                    Rank newRank = new Rank
                    {
                        Rank1 = Rank
                    };

                    db.Rank.Add(newRank);
                    db.SaveChanges();
                    result = "Звание добавлено";
                }
                return result;
            }
        }
        //+изменить звание

        public static string EditRank(Rank oldRank, string newRank)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Rank rank = db.Rank.FirstOrDefault(u => u.id == oldRank.id);
                rank.Rank1 = newRank;
                db.SaveChanges();
                result = "Звание изменено";
            }
            return result;
        }

        //+удалить звание

        public static string DeleteRank(Rank rank)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Rank.Where(u => u.id == rank.id).FirstOrDefault();
                db.Rank.Remove(tmp);
                db.SaveChanges();
                result = "Звание удалено";
            }
            return result;
        }


        //получить звание по id

        public static Rank GetRankById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Rank rank = db.Rank.FirstOrDefault(u => u.id == id);
                return rank;
            }
        }

        //получить сотрудника по id звания

        public static List<Worker> GetAllWorkersByRankId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Worker> workers = (from worker in GetAllWorkers() where worker.idRank == id select worker).ToList();
                return workers;
            }
        }

        //получить звание по id сотрудника

        public static List<Rank> GetAllRanksByWorkerId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Rank> ranks = (from rank in GetAllRanks() where rank.id == id select rank).ToList();
                return ranks;
            }
        }
        //-все нарушения
        public static List<Illegal> GetAllIllegals()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Illegal.ToList();
                return result;
            }
        }

        //-добавить нарушение

        public static string CreateIllegal(string place, string description, IllegalType illegalType, Duty duty, Auto auto, Driver driver)
        {
            string result = "Уже существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Illegal.Any(u => u.Description == description && u.Place == place
                    && u.idAuto == auto.id && u.idDriver == driver.id &&  u.idDuty == duty.id && u.idIllegalType == illegalType.id);
                if (!checkIsExist)
                {
                    Illegal newIllegal = new Illegal
                    {
                        Place = place,
                        Description = description,
                        idIllegalType = illegalType.id,
                        idDuty = duty.id,
                        idAuto = auto.id,
                        idDriver = driver.id
                    };
                    db.Illegal.Add(newIllegal);
                    db.SaveChanges();
                    result = "Нарушение добавлено";
                }
                return result;
            }
        }

        //-изменить нарушение

        public static string EditIllegal(Illegal oldIllegal, string newPlace, string newDescription, 
            IllegalType newIllegalType, Duty newDuty, Auto newAuto, Driver newDriver)
        {
            string result = "Такого нарущения не существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                Illegal illegal = db.Illegal.FirstOrDefault(u => u.id == oldIllegal.id);
                illegal.Place = newPlace;
                illegal.Description = newDescription;
                illegal.idAuto = newAuto.id;
                illegal.idDriver = newDriver.id;
                illegal.idDuty = newDuty.id;
                illegal.idIllegalType = newIllegalType.id;
                db.SaveChanges();
                result = "Нарушения изменено";
            }
            return result;
        }
        //-удалить нарушение

        public static string DeleteIllegal(Illegal illegal)
        {
            string result = "Такого нарушения не существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Illegal.Where(u => u.id == illegal.id).FirstOrDefault();
                db.Illegal.Remove(tmp);
                db.SaveChanges();
                result = "Нарушение удалено";
            }
            return result;
        }

        //автомобили по id нарушения
        public static List<Auto> GetAllAutosByIllegalId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Auto> autos = (from auto in GetAllAutos() where auto.id == id select auto).ToList();
                return autos;
            }
        }
        //водители по id нарушения
        public static List<Driver> GetAllDriversByIllegalId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Driver> drivers = (from driver in GetAllDrivers() where driver.id == id select driver).ToList();
                return drivers;
            }
        }
        //вид нарушения по id нарушения
        public static List<IllegalType> GetAllIllegalTypesByIllegalId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<IllegalType> illegalTypes = (from illegalType in GetAllIllegalTypes() where illegalType.id == id select illegalType).ToList();
                return illegalTypes;
            }
        }
        //дежурство по id нарушения
        public static List<Duty> GetAllDutyByIllegalId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in GetAllDuties() where duty.id == id select duty).ToList();
                return duties;
            }
        }

        public static List<Illegal> GetAllIllegalsByAutoId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Illegal> illegals = (from illegal in GetAllIllegals() where illegal.idAuto == id select illegal).ToList();
                return illegals;
            }
        }

        public static List<Illegal> GetAllIllegalsByDriverId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Illegal> illegals = (from illegal in GetAllIllegals() where illegal.idDriver == id select illegal).ToList();
                return illegals;
            }
        }

        public static List<Illegal> GetAllIllegalsByDutyId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Illegal> illegals = (from illegal in GetAllIllegals() where illegal.idDuty == id select illegal).ToList();
                return illegals;
            }
        }
        public static List<Illegal> GetAllIllegalsByIllegalTypeId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Illegal> illegals = (from illegal in GetAllIllegals() where illegal.idIllegalType == id select illegal).ToList();
                return illegals;
            }
        }

        public static List<Duty> GetAllDutiesByAutoId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in GetAllDuties() where duty.id == id select duty).ToList();
                return duties;
            }
        }

     

        //-все сотрудники
        public static List<Worker> GetAllWorkers()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Worker.ToList();
                return result;
            }
        }


        //-добавить сотрудника
        public static string CreateWorker(string LastName, string FirstName, string Surname, Rank rank)
        {
            string result = "Такой сотрудник уже есть";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExitst = db.Worker.Any(u => u.FirsName == FirstName && u.LastName == u.LastName && u.Surname == Surname && u.idRank == rank.id);
                if (!checkIsExitst)
                {
                    Worker newWorker = new Worker
                    {
                        LastName = LastName,
                        FirsName = FirstName,
                        Surname = Surname,
                        idRank = rank.id
                    };
                    db.Worker.Add(newWorker);
                    db.SaveChanges();
                    result = "Сотрудник добавлен";
                }
                return result;
            }
        }
        //изменить сотрудника

        public static string EditWorker(Worker oldWorker, string newLastName, string newFirstName, string newSurname, Rank newRank)
        {
            string result = "Такого сотрудника не существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                Worker worker = db.Worker.FirstOrDefault(u => u.id == oldWorker.id);
                if(worker != null)
                {
                    worker.FirsName = newFirstName;
                    worker.LastName = newLastName;
                    worker.Surname = newSurname;
                    worker.idRank = newRank.id;
                    db.SaveChanges();
                    result = $"Сострудник изменен";
                }
            }
            return result;
        }

        //-удалить сотрудника
        public static string DeleteWorker(Worker worker)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Worker.Where(u => u.id == worker.id).FirstOrDefault();
                db.Worker.Remove(tmp);
                db.SaveChanges();
                result = "Сотрудник удален";
            }
            return result;
        }

        public static Worker GetWorkerById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Worker worker = db.Worker.FirstOrDefault(u => u.id == id);
                return worker;
            }
        }

        //-все дежурства
        public static List<Duty> GetAllDuties()
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Duty.ToList();
                return result;
            }
        }
        //-добавить дежурство
        public static string CreateDuty(DateTime date, string place, Worker worker) 
        {
            string result = "Уже существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Duty.Any(u => u.Date == date && u.Place == place && u.idWorker == worker.id);
                if (!checkIsExist)
                {
                    Duty newDuty = new Duty
                    {
                        Date = date,
                        Place = place,
                        idWorker = worker.id
                    };
                    db.Duty.Add(newDuty);
                    db.SaveChanges();
                    result = "Дежурство добавлено";
                }
                return result;
            }      
        }
        //-удалить дежурство
        public static string DeleteDuty(Duty duty)
        {
            string result = "Такого дежурства не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Duty.Where(u => u.Date == duty.Date && u.Place == duty.Place && u.idWorker == duty.idWorker)
                    .FirstOrDefault();
                db.Duty.Remove(tmp);
                db.SaveChanges();
                result = "Дежурство удалено";
            }
            return result;
        }

        //-изменить дежурство
        
        public static string EditDuty(Duty oldDuty, DateTime newDate, string newPlace, Worker newWorker)
        {
            string result = "Такого дежурства не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Duty duty = db.Duty.FirstOrDefault(u => u.id == oldDuty.id);
                if(duty != null)
                {
                    duty.Date = newDate;
                    duty.Place = newPlace;
                    duty.idWorker = newWorker.id;
                    db.SaveChanges();
                    result = "Дежурство изменено";
                }             
            }
            return result;
        }

        public static Duty GetDutyById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Duty duty = db.Duty.FirstOrDefault(u => u.id == id);
                return duty;
            }
        }
        //Получить дежурство по id сотрудника
        public static List<Duty> GetAllDutiesByWorkerId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in GetAllDuties() where duty.idWorker == id select duty).ToList();
                return duties;
            }
        }

        //Получить сотрудика по id дежурства
        public static List<Worker> GetAllWorkersByDutyId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Worker> workers = (from worker in GetAllWorkers() where worker.id == id select worker).ToList();
                return workers;
            }
        }
        //-получить учет 
        public static List<Accounting> GetAllAccountings()
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Accounting.ToList();
                return result;
            }
        }
        //-добавить учет
        public static string CreateAccounting(string number, string color, DateTime firstDate, DateTime lastDate, Worker worker, 
            Driver driver, Auto auto)
        {
            string result = "Уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Accounting.Any(u => u.Number == number && u.Color == color && u.FirstDate == firstDate
                && u.LastDate == lastDate && u.idWorker == worker.id && u.idDriver == driver.id && u.idAuto == auto.id);
                if (!checkIsExist)
                {
                    Accounting accounting = new Accounting{
                        Number = number,
                        Color = color,
                        FirstDate = firstDate,
                        LastDate = lastDate,
                        idWorker = worker.id,
                        idDriver = driver.id,
                        idAuto = auto.id
                    };
                    db.Accounting.Add(accounting);
                    db.SaveChanges();
                    result = "Автомобиль поставлен на учет";
                }
                return result;
            }
        }

        //-изменить учет
        public static string EditAccounting(Accounting oldAccounting,string newNumber, string newColor, DateTime newFirstDate,
            DateTime newLastDate, Worker newWorker,Driver newDriver, Auto newAuto)
        {
            string result = "Такой записи не существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                Accounting accounting = db.Accounting.FirstOrDefault(u => u.id == oldAccounting.id);
                if(accounting != null)
                {
                    accounting.Number = newNumber;
                    accounting.Color = newColor;
                    accounting.FirstDate = newFirstDate;
                    accounting.LastDate = newLastDate;
                    accounting.idWorker = newWorker.id;
                    accounting.idDriver = newDriver.id;
                    accounting.idAuto = newAuto.id;
                    db.SaveChanges();
                    result = "Запись изменена";
                }
                return result;
            }

        }
        //-удалить учет 
        public static string DeleteAccounting(Accounting accounting)
        {
            string result = "Такого автомобиля не существует";
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Accounting.Where(u => u.id == accounting.id).FirstOrDefault();
                db.Accounting.Remove(tmp);
                db.SaveChanges();
                result = "Автомобиль снят с учета";
            }
            return result;
        }

        /*
          public static List<Duty> GetAllDutiesByAutoId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in GetAllDuties() where duty.id == id select duty).ToList();
                return duties;
            }
        }
         */
        public static List<Accounting> GetAllAccountingsByAutoId(int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }

        public static List<Accounting> GetAllAccountingsByDriverId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }
        public static List<Accounting> GetAllAccountingsByWorkerId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
