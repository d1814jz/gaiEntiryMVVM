using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories
{
    class IllegalRepositories
    {
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
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Illegal.Any(u => u.Description == description && u.Place == place
                    && u.idAuto == auto.id && u.idDriver == driver.id && u.idDuty == duty.id && u.idIllegalType == illegalType.id);
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
            using (gaiEngEntities db = new gaiEngEntities())
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
            using (gaiEngEntities db = new gaiEngEntities())
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
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Auto> autos = (from auto in AutoRepositories.GetAllAutos() where auto.id == id select auto).ToList();
                return autos;
            }
        }
        //водители по id нарушения
        public static List<Driver> GetAllDriversByIllegalId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Driver> drivers = (from driver in DriverRepositories.GetAllDrivers() where driver.id == id select driver).ToList();
                return drivers;
            }
        }
        //вид нарушения по id нарушения
        public static List<IllegalType> GetAllIllegalTypesByIllegalId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<IllegalType> illegalTypes = (from illegalType in IllegalTypeRepositories.GetAllIllegalTypes() where illegalType.id == id select illegalType).ToList();
                return illegalTypes;
            }
        }
        //дежурство по id нарушения
        public static List<Duty> GetAllDutyByIllegalId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in DutyRepositories.GetAllDuties() where duty.id == id select duty).ToList();
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
                List<Duty> duties = (from duty in DutyRepositories.GetAllDuties() where duty.id == id select duty).ToList();
                return duties;
            }
        }
    }
}
