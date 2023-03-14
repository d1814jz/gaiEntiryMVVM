using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Interface;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories 
{
    class AutoRepositories
    {
        public static List<Auto> GetAllAutos()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Auto.ToList();
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

        //+получить автомобили


        //получить автомобиль по id
        public static Auto GetAutoById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Auto auto = db.Auto.FirstOrDefault(u => u.id == id);
                return auto;
            }
        }
    }
}
