using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories
{
    class DriverRepositories
    {
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
    }
}
